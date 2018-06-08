using AutoMapper;
using ExercisesAPI.Automapper;
using ExercisesAPI.Data.Models;
using ExercisesAPI.Data.Repositories.Implementations;
using ExercisesAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ExercisesAPI
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
            services.AddDbContext<ExercisesContext>();
            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<IExerciseCategoryRepository, ExerciseCategoryRepository>();
            services.AddTransient<IExerciseTipRepository, ExerciseTipRepository>();
            services.AddMvc();
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new AutoMapperProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            //Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            services.AddSwaggerGen(o =>
                {
                    o.SwaggerDoc("v1", new Info { Title = "Exercises API", Description = "Swagger Exercises API" });
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(o =>
                {
                    o.SwaggerEndpoint("/swagger/v1/swagger.json", "Exercises API");
                }
            );
        }
    }
}
