using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThinkerThings.BLL.Common;
using ThinkerThings.BLL.Service;
using ThinkerThings.BLL.Service.Devices;
using ThinkerThings.Core.Repositories.Common;
using ThinkerThings.Core.Services;
using ThinkerThings.Core.Services.Common;
using ThinkerThings.Core.Services.Device;
using ThinkerThings.Core.UnitOfWork;
using ThinkerThings.DAL;
using ThinkerThings.DAL.Repositories.Common;
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

            services.AddControllers();
            services.AddSwaggerDocument();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IDeviceRepository<>), typeof(DeviceRepository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(IDeviceService<>), typeof(DeviceService<>));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(INetworkService), typeof(NetworkService));
            services.AddScoped(typeof(IMotionDateService), typeof(MotionDateService));
            services.AddScoped(typeof(IGatewayService), typeof(GatewayService));
            services.AddScoped(typeof(IAirConditionerService), typeof(AirConditionerService));
            services.AddScoped(typeof(IMotionSensorService), typeof(MotionSensorService));
            services.AddScoped(typeof(ISmartLampService), typeof(SmartLampService));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

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

            app.UseRouting();
            
            app.UseAuthorization();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
