using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using my_books_store.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_books_store.Data.Services;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace my_books_store
{
    public class Startup
    {
        public string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = configuration.GetConnectionString("MyDBConnection");

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //Configuarion DependencyInjection connection DBcontext with SQL --**Milind
            services.AddDbContext<appDbContext>(options => options.UseSqlServer(ConnectionString));

            //Configure DJ new Book Service --AddTransient: A new instance of the service is created each time it is requested. This is ideal for lightweight, stateless services.
            services.AddTransient<BookService>();
            services.AddTransient<AuthorsService>();
            services.AddTransient<PublishersService>();

            //*api versioning
            //services.AddApiVersioning(); for not set this default specified just DependencyInjection for versioninh
            //configuring default
            services.AddApiVersioning(config=>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;

                //config.ApiVersionReader = new HeaderApiVersionReader("custom-version-header");//for HTTP based 
                //config.ApiVersionReader = new MediaTypeApiVersionReader();// HTTP Media Type-Based  

            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "my_books_store", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "my_books_store v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Configure DependencyInjection service DbInitializer Class
            AppDbInitializer.Seed(app);
        }
    }
}
