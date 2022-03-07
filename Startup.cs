using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Contexts;
using backend.DTO;
using backend.Entities;
using backend.Implementations;
using backend.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace backend
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(mapper=> {
                mapper.CreateMap<CategoryDTO, Category>().ReverseMap();
                mapper.CreateMap<MediaDTO, Media>().ReverseMap();
                mapper.CreateMap<TypeMediaDTO, TypeMedia>();
            });

            services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                  builder.WithOrigins("http://localhost:8080","http://localhost:8081","http://localhost:8082")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                              });
        });
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMediaRepository, MediaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ItypeMediaRepository, TypeMediaRepository>();

            var db_connection = Configuration.GetConnectionString("DB_CONNECTION");
            services.AddDbContext<Context>(options => 
            options.UseMySql(db_connection, ServerVersion.AutoDetect(db_connection)).EnableSensitiveDataLogging()
            );
             services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
