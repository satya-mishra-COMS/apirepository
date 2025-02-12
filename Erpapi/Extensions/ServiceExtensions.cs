namespace Erpapi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
           services.AddCors(options => options.AddPolicy("LGQLogisticPolicy", 
               builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

    }
}
