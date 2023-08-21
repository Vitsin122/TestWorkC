using Microsoft.EntityFrameworkCore;
using TestWorkC.DataContext;


namespace TestWorkC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            ConfigurationManager configuration = builder.Configuration;
            string connection = configuration.GetConnectionString("IndConnection");

            builder.Services.AddDbContext<NpgApplicationContext>(options => options.UseNpgsql(connection));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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