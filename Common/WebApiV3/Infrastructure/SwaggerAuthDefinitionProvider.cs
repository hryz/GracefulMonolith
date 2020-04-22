using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApiV3.Infrastructure
{
    public class SwaggerAuthDefinitionProvider : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var secure = context.ApiDescription.ActionDescriptor.FilterDescriptors.Any(x => x.Filter is AuthorizeFilter);
            if (!secure)
            {
                return;
            }

            if (operation.Security == null)
            {
                operation.Security = new List<OpenApiSecurityRequirement>();
            }

            var oAuthRequirements = new OpenApiSecurityRequirement
            {
                {new OpenApiSecurityScheme {Type = SecuritySchemeType.OAuth2}, new Collection<string>()}
            };


            operation.Security.Add(oAuthRequirements);
        }
    }
}
