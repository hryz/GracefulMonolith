using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Infrastructure
{
    public class SwaggerFluentValidationProvider : ISchemaFilter
    {
        private readonly IServiceProvider _factory;


        public SwaggerFluentValidationProvider(IServiceProvider factory)
        {
            _factory = factory;
        }

        public void Apply(Schema model, SchemaFilterContext context)
        {
            var validator = _factory.GetService(typeof(AbstractValidator<>).MakeGenericType(context.SystemType)) as IValidator;
            if (validator == null)
            {
                return;
            }

            if (model.Required == null)
            {
                model.Required = new List<string>();
            }

            var validatorDescriptor = validator.CreateDescriptor();
            foreach (var key in model.Properties.Keys)
            {
                foreach (var propertyValidator in validatorDescriptor.GetValidatorsForMember(ToPascalCase(key)))
                {
                    if (propertyValidator is NotNullValidator || propertyValidator is NotEmptyValidator)
                    {
                        model.Required.Add(key);
                    }

                    SetValidationRule(model.Properties[key], propertyValidator);
                }
            }
        }

        private static void SetValidationRule(Schema schema, IPropertyValidator propertyValidator)
        {
            if (propertyValidator is LengthValidator lengthValidator)
            {
                if (lengthValidator.Max > 0)
                {
                    schema.MaxLength = lengthValidator.Max;
                }

                if (lengthValidator.Min > 0)
                {
                    schema.MinLength = lengthValidator.Min;
                }
            }

            if (propertyValidator is GreaterThanValidator g && g.ValueToCompare is int gt)
            {
                schema.Minimum = gt + 1;
            }

            if (propertyValidator is GreaterThanOrEqualValidator ge && ge.ValueToCompare is int gte)
            {
                schema.Minimum = gte;
            }

            if (propertyValidator is LessThanValidator l && l.ValueToCompare is int lt)
            {
                schema.Maximum = lt - 1;
            }

            if (propertyValidator is LessThanOrEqualValidator le && le.ValueToCompare is int lte)
            {
                schema.Maximum = lte;
            }

            if (propertyValidator is InclusiveBetweenValidator ib && ib.From is int ibf && ib.To is int ibt)
            {
                schema.Minimum = ibf;
                schema.Maximum = ibt;
            }

            if (propertyValidator is ExclusiveBetweenValidator eb && eb.From is int ebf && eb.To is int ebt)
            {
                schema.Minimum = ebf + 1;
                schema.Maximum = ebt - 1;
            }

            if (propertyValidator is RegularExpressionValidator regExValidator)
            {
                schema.Pattern = regExValidator.Expression;
            }

            if (propertyValidator is EmailValidator)
            {
                schema.Type = "string";
                schema.Format = "email";
            }
        }

        private static string ToPascalCase(string inputString)
        {
            if (inputString == null)
            {
                return null;
            }

            if (inputString.Length < 2)
            {
                return inputString.ToUpper();
            }

            return inputString.Substring(0, 1).ToUpper() + inputString.Substring(1);
        }
    }
}
