using System;
using Application.Customers.Validators;
using Data.Read.Customers.Validators;
using FluentValidation.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;

namespace Tests.Integration
{
    [TestClass]
    public class ValidatorCoverageTest
    {
        [DataTestMethod]
        [FluentValidationDataSource(
            controllerAssembly: new[]
            {
                typeof(CustomerController) //controllers
            },
            validatorAssembly: new[]
            {
                typeof(GetCustomerListValidator), //queries
                typeof(RegisterCustomerValidator) //commands
            },
            ignoreTypes: new[]
            {
                typeof(string),
                typeof(decimal),
                typeof(DateTime),
                typeof(Guid)
            })]
        public void EverythingIsCovered(FluentValidationTestContext ctx)
        {
            FluentValidationTestRunner.Check(ctx);
        }
    }
}
