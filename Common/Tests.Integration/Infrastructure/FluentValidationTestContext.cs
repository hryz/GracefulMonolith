using System;
using System.Reflection;

namespace FluentValidation.Testing
{
    public class FluentValidationTestContext
    {
        public FluentValidationTestContext(
            Type controller,
            MethodInfo action,
            ParameterInfo parameter,
            bool isValidated)
        {
            Controller = controller;
            Action = action;
            Parameter = parameter;
            IsValidated = isValidated;
        }

        public Type Controller { get; }
        public MethodInfo Action { get; }
        public ParameterInfo Parameter { get; }
        public bool IsValidated { get; }
    }
}