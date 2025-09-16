
using EduStudentAPI.Data;
using EduStudentAPI.Data.Config;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EduStudentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            #region Serilog Configuration

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(path: "Log/log.txt",rollingInterval: RollingInterval.Day,fileSizeLimitBytes: 10485760 // 10 MB per file
                ,retainedFileCountLimit: 31 , rollOnFileSizeLimit: true) 
                .MinimumLevel.Verbose()
                .CreateLogger();

            //builder.Host.UseSerilog(); //This only uses serilog for logging and disables other loggers
            builder.Logging.AddSerilog(); //This uses serilog along with other loggers

            #endregion
            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CollegeDBContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"))
            );

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
