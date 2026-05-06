using LoggingTask.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LoggingTask.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddAutoMapper(cfg =>
        {
            cfg.LicenseKey =
                "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxODA1MjQxNjAwIiwiaWF0IjoiMTc3Mzc2Mjg3NiIsImFjY291bnRfaWQiOiIwMTljZmM4MGZmZDA3NmEyYmVhMWUzODM3MjJiMTBmNSIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa2t5ODM1OXZ3OHhjcW4wbXB4OGJ2d2dqIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.Unx2jOCu8gr_W-H-fJgMBDj1ogtz61Gh83Rwqg2pLtRHEh64qoXm1BLNs6VaZsCrrADMbpqvCfsXjfRWejnOan4SE3sxI9rdYbZNW6bpsZfWjpZDuQIsOWJlfhbAnlcZhW_faTsqys-pZ0-3vgLhQ1dpQ77HvvnO3Lhiw64zRv4mq-RSNxbLOBXNx5dU2dODMXdlcq9deC4-e2x0a9gOVYFx_Bj0EX-1l5Kq55LKqfo0ig2yeoYSKVn6mx1jbIyqxTPBtABDwswTBVcfc2AYgAA9sLcpoAOYPApx2FWk6cl8MhnO3QzGMmyuaJyutXeTJ2ZRcBbC6__oL8v_xxs1wg";
        });
        
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<MyDbContext>(
            options => options.UseNpgsql(
                builder.Configuration.GetConnectionString("DefaultConnection")
            )
        );

        builder.Services.AddControllers();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}