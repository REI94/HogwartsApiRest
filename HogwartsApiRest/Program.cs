using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Relate some classes to their respective interfaces.
builder.Services.AddTransient<IStudentRepository, StudentRepository>()
    .AddTransient<IStudentService, StudentService>();

builder.Services.AddDbContext<HogwartsApiRestDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //Describe in the index.html some relevant information about the API.
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hogwarts API REST",
        Version = "v1",
        Description = "API REST for the registration of applications from students who want to be part of the school of magic Hogwarts."
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hogwarts API REST v1");

        //Set Swagger as default index page. 
        c.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();