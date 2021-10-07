using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NetCoreAPIPostgreSQL.Data;
using NetCoreAPIPostgreSQL.Data.Bill_Repository;
using NetCoreAPIPostgreSQL.Data.BranchRepository;
using NetCoreAPIPostgreSQL.Data.ClassificationRepository;
using NetCoreAPIPostgreSQL.Data.Client_Repository;
using NetCoreAPIPostgreSQL.Data.Directors_Repository;
using NetCoreAPIPostgreSQL.Data.Employee_Repository;
using NetCoreAPIPostgreSQL.Data.Movie_Repository;
using NetCoreAPIPostgreSQL.Data.Projection_Repository;
using NetCoreAPIPostgreSQL.Data.Protagonist_Repository;
using NetCoreAPIPostgreSQL.Data.RolRepository;
using NetCoreAPIPostgreSQL.Data.Room_Repository;
using NetCoreAPIPostgreSQL.Data.Seat_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL
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

            var postgreSQLConnectionConfiguration = new PostgreSQLConfiguration(Configuration.GetConnectionString("PostgreSQLConnection"));
            services.AddSingleton(postgreSQLConnectionConfiguration);

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IDirectorsRepository, DirectorsRepository>();
            services.AddScoped<IClassificationRepository, ClassificationRepository>();
            services.AddScoped<IProtagonistRepository, ProtagonistRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IProjectionRepository, ProjectionRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetCoreAPIPostgreSQL", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCoreAPIPostgreSQL v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
