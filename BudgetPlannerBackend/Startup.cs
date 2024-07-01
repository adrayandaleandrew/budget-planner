// Startup.cs

using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                    .AllowAnyOrigin() // You can specify more restrictive origins here
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Content-Disposition")); // Optional: specify exposed headers
        });

        services.AddControllers();
        // Add other services as needed
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseCors("CorsPolicy");

        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
