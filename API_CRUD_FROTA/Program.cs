using API_CRUD_FROTA.Data;
using API_CRUD_FROTA.Repository;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace API_CRUD_FROTA {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var conenectionString = builder.Configuration.GetConnectionString("ConnectionMysql");
            builder.Services.AddDbContext<BancoContext>(
                options => options.UseMySql(conenectionString, ServerVersion.Parse("8.1.32")) //Detalhe, neste local é inserido a versão do seu server. 
                );
            builder.Services.AddScoped<IOnibusRepository, OnibusRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
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