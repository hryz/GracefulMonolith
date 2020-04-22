using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApiV3.Infrastructure
{
    public class SwaggerSampleModelProvider : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (model?.Properties?.Keys == null)
            {
                return;
            }

            foreach (var key in model.Properties.Keys)
            {
                model.Properties[key].ReadOnly = false;
            }
        }

    }
}
