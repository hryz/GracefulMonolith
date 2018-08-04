using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Infrastructure
{
    public class SwaggerAuthDefinitionProvider : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var secure = context.ApiDescription.ActionDescriptor.FilterDescriptors.Any(x => x.Filter is AuthorizeFilter);
            if (!secure)
            {
                return;
            }

            if (operation.Security == null)
            {
                operation.Security = new List<IDictionary<string, IEnumerable<string>>>();
            }

            var oAuthRequirements = new Dictionary<string, IEnumerable<string>>
            {
                { "oauth2", Enumerable.Empty<string>() }
            };

            operation.Security.Add(oAuthRequirements);
        }
    }
}
