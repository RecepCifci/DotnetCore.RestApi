using Hepsiburada.RestApi.Business.Abstract;
using Hepsiburada.RestApi.Business.Concrete;
using Hepsiburada.RestApi.DataAccess.Abstract;
using Hepsiburada.RestApi.DataAccess.Concrete;
using Hepsiburada.RestApi.DataAccess.Concrete.MongoDb.Contexts;
using Hepsiburada.RestApi.DataAccess.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;


namespace Hepsiburada.RestApi.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hepsiburada.RestApi.Api", Version = "v1" });
            });

            services.Configure<DbSettings>(Configuration.GetSection("MongoConnection"));

            services.AddSingleton<MongoDbContext>();

            services.AddScoped<IContext, MongoDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<RedisCache<Product>>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetValue<string>("CacheSettings:ConnectionString");
            });

            services.AddAutoMapper(typeof(AutoMapperProfiles));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hepsiburada.RestApi.Api v1"));
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
