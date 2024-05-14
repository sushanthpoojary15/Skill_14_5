using CollaboSphere.Common;
using CollaboSphere.Web.API;
using CollaboSphere.Web.API.Infrastructure;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

var configRoot = new
{
    AppSettings = new AppSettings()
};

configuration.Bind(configRoot);

// Add services to the container.
builder.Services.RegisterDependency(configRoot.AppSettings);

builder.Services.AddControllers().AddJsonOptions(x =>
              x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});


//builder.Services.AddSpaStaticFiles(configuration =>
//{
//    configuration.RootPath = "ClientApp/dist/CollabSphere";
//});


builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = long.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();


app.UseMiddleware<AuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
