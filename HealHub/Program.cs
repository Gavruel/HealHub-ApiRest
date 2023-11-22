using HealHub.Domain.Interfaces;
using HealHub.Infra;
using HealHub.Services;
using Microsoft.EntityFrameworkCore;

namespace HealHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connection =
            builder.Configuration.GetConnectionString("OracleConnection");
            builder.Services.AddDbContext<OracleDbContext>(options =>
            options.UseOracle(connection));

            // Add services to the container.

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IFormService, FormService>();

            builder.Services.AddScoped<IPrognosisService, PrognosisService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}