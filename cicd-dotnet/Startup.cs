using cicd_dotnet.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace cicd_dotnet
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MathService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.ContentType = "text/html";
                    string response = "Hello World!<br/><button onclick=\"window.location.href='/new-page';\">Go to New Page</button>";
                    await context.Response.WriteAsync(response);
                });

                endpoints.MapGet("/new-page", async context =>
                {
                    await context.Response.WriteAsync("New Page");
                });
            });
        }
    }
}
