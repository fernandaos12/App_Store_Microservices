using AutoMapper;
using GeekShopping.Api.Data.ObjectDTO.MapConfig;
using GeekShopping.Api.Model.Context;
using GeekShopping.Api.Repository;
using GeekShopping.Api.Repository.Interfaces;
using GeekShopping.Api.Services;
using GeekShopping.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var connectionString = builder.Configuration["MySqlConnection:MySQlConnectionString"];
        builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29))));
        builder.Services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.ProductApi" }));

        // IMapper mapper = MapConfig.RegisterMaps().CreateMapper();
        //builder.Services.AddSingleton(mapper);
       // builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddAutoMapper(typeof(MapProfile));
        

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();        
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

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