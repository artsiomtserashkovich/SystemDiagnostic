using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
            services.AddDbContext<ApplicationDataBaseContext>(options => 
                options.UseSqlServer("Data Source = localhost\\SQLEXPRESS; Initial Catalog = SystemDiagnostic; Integrated Security = True", 
                    b => b.MigrationsAssembly("SystemDiagnostic.DataBaseMigration")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
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
