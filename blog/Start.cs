
using Blog.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL; // Make sure to add this using directive

namespace Blog
{

    public class Start
    {
        public void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy("Cors", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMvc();
            services.AddResponseCompression();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public void Configure(WebApplication app, IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "auth-deneme v1"));
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "auth-deneme v1"));
                app.UseHsts();
            }

            app.UseResponseCompression();

            if (!app.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }


            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
        }
    }

}