using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidation.Testing
{
    public class FluentValidationTestRunner
    {
        public static void Check(FluentValidationTestContext ctx)
        {
            if(!ctx.IsValidated) Assert.Fail($"A validator for the type {ctx.Parameter.ParameterType.Name} was not found");
        }
    }
}
