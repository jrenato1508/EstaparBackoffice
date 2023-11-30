using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace EstaparBackoffice.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
            //services.AddControllers().ConfigureApiBehaviorOptions(setupAction => { setupAction.SuppressModelStateInvalidFilter = true; }); 

            services.AddControllers();

            services.AddApiVersioning(option =>
            {
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ReportApiVersions = true;
            })
                .AddApiExplorer(option =>
                {
                    option.GroupNameFormat = "'v'VVV";
                    option.SubstituteApiVersionInUrl = true;
                });



            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });



            return services;
        }


        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();



            return app;
        }
    }
}
