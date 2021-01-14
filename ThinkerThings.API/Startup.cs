using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using ThinkerThings.API.Middleware;
using ThinkerThings.API.RTC.SignalR;
using ThinkerThings.API.RTC.WebSocketHub.Devices;
using ThinkerThings.BLL.Common;
using ThinkerThings.BLL.Service;
using ThinkerThings.BLL.Service.Devices;
using ThinkerThings.Core.Repositories;
using ThinkerThings.Core.Repositories.Common;
using ThinkerThings.Core.Repositories.Device;
using ThinkerThings.Core.Services;
using ThinkerThings.Core.Services.Common;
using ThinkerThings.Core.Services.Device;
using ThinkerThings.Core.UnitOfWork;
using ThinkerThings.DAL;
using ThinkerThings.DAL.Repositories.Common;
using ThinkerThings.DAL.Repositories.Devices;
using ThinkerThings.DAL.UnitOfWork;

namespace ThinkerThings.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                });
                options.AddPolicy("HubPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });

            });
            services.AddControllers();
            services.AddSwaggerDocument();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IMotionSensorRepository), typeof(MotionSensorRepository));
            services.AddScoped(typeof(IAirConditionerRepository), typeof(AirConditionerRepository));
            services.AddScoped(typeof(ISmartLampRepository), typeof(SmartLampRepository));
            services.AddScoped(typeof(IDeviceRepository<>), typeof(DeviceRepository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(IDeviceService<>), typeof(DeviceService<>));
            services.AddScoped(typeof(IDeviceService<>), typeof(DeviceService<>));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(INetworkService), typeof(NetworkService));
            services.AddScoped(typeof(IMotionDateService), typeof(MotionDateService));
            services.AddScoped(typeof(IAirConditionerService), typeof(AirConditionerService));
            services.AddScoped(typeof(IMotionSensorService), typeof(MotionSensorService));
            services.AddScoped(typeof(ISmartLampService), typeof(SmartLampService));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<SmartLampWebSocketHub>();
            services.AddScoped<AirConditionerWebSocketHub>();

            services.AddSignalR();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:PostgreSqlConStr"].ToString());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(1024)

            };
            app.UseRouting();
            app.UseAuthorization();
            app.UseOpenApi();
            app.UseWebSockets();
            app.UseMiddleware<WebSocketHandleMiddleware>();
            app.UseCors("HubPolicy");
            app.UseCors();
            app.UseSwaggerUi3();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SmartLampHub>("/smartlamp");
                endpoints.MapHub<AirConditionerHub>("/airconditioner");
            });
        }
    }
}


