using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering;
public static class OderingModule {
    public static IServiceCollection AddOrderingModule(this IServiceCollection services, IConfiguration configuration) {
        // Add services to the container.
        // services.AddScoped<IOrderService, OrderService>();
        // services.AddScoped<IOrderRepository, OrderRepository>();
        return services;
    }

    public static IApplicationBuilder UseOrderingModule(this IApplicationBuilder app) {
        // Configure the HTTP request pipeline.
        // app.UseEndpoints(endpoints => {
        //     endpoints.MapControllers();
        // });
        return app;
    }
    }
