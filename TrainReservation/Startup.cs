using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TrainReservation.Middlewares;
using TrainReservation.Persistance.Extensions;

namespace TrainReservation
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddObjectGenerate();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TrainReservation", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("Cors", build =>
                  build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrainReservation v1"));
            }
            app.UseTryCatch();
            app.UseRouting();
            app.UseCors("Cors");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
