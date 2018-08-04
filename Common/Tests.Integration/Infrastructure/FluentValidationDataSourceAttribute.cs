using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidation.Testing
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FluentValidationDataSourceAttribute : Attribute, ITestDataSource
    {
        private readonly Type[] _ignoreTypes;
        private readonly Assembly[] _controllerAssembly;
        private readonly Assembly[] _validatorAssembly;

        /// <summary>
        /// Provides a data set of all controller actions and validators for MSTest framework
        /// </summary>
        /// <param name="controllerAssembly">A type from the controller assembly</param>
        /// <param name="validatorAssembly">A type from the the validator assembly</param>
        /// <param name="ignoreTypes">types that do not require validation</param>
        public FluentValidationDataSourceAttribute(Type[] controllerAssembly, Type[] validatorAssembly, Type[] ignoreTypes)
        {
            _ignoreTypes = ignoreTypes;
            _controllerAssembly = controllerAssembly.Select(x => x.Assembly).ToArray();
            _validatorAssembly = validatorAssembly.Select(x => x.Assembly).ToArray();
        }

        public bool CheckPrimitiveTypes { get; set; } = false;
        public bool CheckEnums { get; set; } = false;
        public bool CheckCancellationTokens { get; set; } = false;
        public bool CheckServices { get; set; } = false;

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            // AbstractValidator<T> where T : api model
            var validatedTypes = _validatorAssembly.SelectMany(x => x.GetTypes())
                .Where(t => typeof(IValidator).IsAssignableFrom(t) && t.BaseType != null && t.BaseType.IsGenericType)
                .Select(v => v.BaseType?.GetGenericArguments()[0])
                .ToList();

            bool IsValidated(Type t) => validatedTypes.Any(x => x == t);
            bool IsService(ParameterInfo p) => p.CustomAttributes.Any(a => a.AttributeType == typeof(FromServicesAttribute));

            return _controllerAssembly
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(ControllerBase).IsAssignableFrom(x))
                .SelectMany(c =>
                    c.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                        .SelectMany(m => m.GetParameters()
                            .Where(p => (CheckPrimitiveTypes || !p.ParameterType.IsPrimitive)
                                        && (CheckEnums || !p.ParameterType.IsEnum)
                                        && (CheckCancellationTokens || p.ParameterType != typeof(CancellationToken))
                                        && (CheckServices || !IsService(p))
                                        && !_ignoreTypes.Contains(p.ParameterType))
                            .Select(p => new object[] { new FluentValidationTestContext(c, m, p, IsValidated(p.ParameterType)) })));
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            // ReSharper disable once UseNegatedPatternMatching
            var context = data?.FirstOrDefault() as FluentValidationTestContext;
            if (context == null)
                return null;

            // ReSharper disable once UseStringInterpolation
            return string.Format("{0}.{1}({2} {3})",
                context.Controller.Name,
                context.Action.Name,
                context.Parameter.ParameterType.Name,
                context.Parameter.Name);
        }
    }
}
