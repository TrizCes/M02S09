using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(
                IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        CreateVersionInfo(description));
                }
        }

            public void Configure(string name, SwaggerGenOptions options)
            {
                Configure(options);
            }

            private OpenApiInfo CreateVersionInfo(
                    ApiVersionDescription description)
            {
                var info = new OpenApiInfo()
                {
                    Title = "University",
                    Version = description.ApiVersion.ToString()
                };

                if (description.IsDeprecated)
                {
                    info.Description += " Essa versão está depreciada.";
                }

                return info;
            }
    } 
}
