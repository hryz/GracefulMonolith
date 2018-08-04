using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Infrastructure
{
    public class SwaggerSampleModelProvider : ISchemaFilter
    {
        public void Apply(Schema model, SchemaFilterContext context)
        {
            if (model?.Properties?.Keys == null)
            {
                return;
            }

            foreach (var key in model.Properties.Keys)
            {
                model.Properties[key].ReadOnly = null;
            }
        }
    }
}
