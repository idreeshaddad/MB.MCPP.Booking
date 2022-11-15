using FluentValidation;
using FluentValidation.AspNetCore;
using MB.MCPP.BK.Dtos.Customers;
using MB.MCPP.BK.EfCore;
using MB.MCPP.BK.WebApi.FluentValidations;
using Microsoft.EntityFrameworkCore;
using System;

namespace MB.MCPP.BK.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Register all AutoMapper profiles
            builder.Services.AddAutoMapper(typeof(Program));


            // Register all FluentValidation validator 
            //builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();


            builder.Services.AddDbContext<BookingDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("BookingAppConnection")));

            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            //-------------------------------------------

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("corsapp");

            app.MapControllers();

            app.Run();
        }
    }
}