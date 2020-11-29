namespace Pizzeria.Server
{
    using System.Reflection;
    using AutoMapper;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Middleware;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase(this.Configuration)
                .AddIdentity()
                .AddJwtAuthentication(this.Configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddApplicationServices()
                .AddApiControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
            => app
                .UseExceptionHandling(env)
                .UseValidationExceptionHandler()
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAnyCors()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints()
                .Initialize();
    }
}
