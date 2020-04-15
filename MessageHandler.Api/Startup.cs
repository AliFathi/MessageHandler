using MessageHandler.Api.MessageHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageHandler.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o => o.EnableEndpointRouting = false);
            services.AddScoped<IMessageHandlerProvider, MessageHandlerProvider>();

            services.AddMessageHandler<DefaultMessageHandler>(MessageType.Unknwon);
            services.AddMessageHandler<FirstMessageHandler>(MessageType.First);
            services.AddMessageHandler<SecondMessageHandler>(MessageType.Second);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler();

            app.UseMvc();
        }
    }
}
