using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SpaceObjects.Api.DataAccessLayer;
using SpaceObjects.Api.DTO;
using SpaceObjects.Api.Mapper;
using SpaceObjects.Api.Models;
using SpaceObjects.Api.Validators;

namespace SpaceObjects.Api
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
            var mapperConfig = new MapperConfiguration(mc =>
            {                
                mc.AddProfile(new ProfileMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().AddFluentValidation();
            services.AddScoped<ISpaceObjectRepository, SpaceObjectRepository>();
            services.AddScoped<IValidator<AsteroidDto>, AsteroidDtoValidator>();
            services.AddScoped<IValidator<StarDto>, StarDtoValidator>();
            services.AddScoped<IValidator<PlanetDto>, PlanetDtoValidator>();
            services.AddScoped<IValidator<BlackHoleDto>, BlackHoleDtoValidator>();
            services.AddScoped<IValidator<Asteroid>, AsteroidValidator>();
            services.AddScoped<IValidator<Star>, StarValidator>();
            services.AddScoped<IValidator<Planet>, PlanetValidator>();
            services.AddScoped<IValidator<BlackHole>, BlackHoleValidator>();
            services.AddControllers();
            services.AddDbContext<ApplicationSpaceObjectContext>(opt =>
                                                      opt.UseSqlite("name = ConnectionStrings:DefaultConnection"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpaceObjects.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpaceObjects.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
