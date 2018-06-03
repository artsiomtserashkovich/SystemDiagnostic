using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.BLL.Services;
using SystemDiagnostic.DAL;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;

namespace SystemDiagnostic.WebAPI
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
            services.AddMvc();
            services.AddAutoMapper(typeof(BLL.MapperProfile.BLLMapperProfile));
            services.AddDbContext<ApplicationDataBaseContext>(options =>
                options.UseSqlServer("Data Source = localhost\\SQLEXPRESS; Initial Catalog = SystemDiagnostic; Integrated Security = True",
                    b => b.MigrationsAssembly("SystemDiagnostic.WebAPI")));
            services.AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IComputerService,ComputerService>()
                .AddScoped<IComputerSystemService,ComputerSystemService>()
                .AddScoped<IProcessorService,ProcessorService>()
                .AddScoped<IMotherBoardService,MotherBoardService>()
                .AddScoped<IVideoCardService,VideoCardService>()
                .AddScoped<IPhysicalMemoryService,PhysicalMemoryService>()
                .AddScoped<IDiskDriveService,DiskDriveService>()
                .AddScoped<IProcessService,ProcessService>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
