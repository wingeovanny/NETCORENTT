using Microsoft.OpenApi.Models;
using ntt.micros.core.cuentas.api.Extentions;
using ntt.micros.core.cuentas.application.ioc;
using ntt.micros.core.cuentas.infrastructure.ioc;
using Microsoft.EntityFrameworkCore;
using ntt.micros.core.cuentas.infrastructure.data.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors();
builder.Services.AddControllers();
//builder.Services.AddControllers().AddJsonOptions(x =>
//{
//    // serialize enums as strings in api responses (e.g. Role)
//    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

//    // ignore omitted parameters on models to enable optional params (e.g. User update)
//    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
//});
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc(builder.Configuration["OpenApi:info:version"], new OpenApiInfo
    {
        Version = builder.Configuration["OpenApi:info:version"],
        Title = builder.Configuration["OpenApi:info:title"],
        Description = builder.Configuration["OpenApi:info:description"],
        TermsOfService = new Uri(builder.Configuration["OpenApi:info:termsOfService"]),
        Contact = new OpenApiContact
        {
            Name = builder.Configuration["OpenApi:info:contact:name"],
            Url = new Uri(builder.Configuration["OpenApi:info:contact:url"]),
            Email = builder.Configuration["OpenApi:info:contact:email"]
        },
        License = new OpenApiLicense
        {
            Name = builder.Configuration["OpenApi:info:License:name"],
            Url = new Uri(builder.Configuration["OpenApi:info:License:url"])
        }
    });

    List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
    xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

});

//Dependencias propias de Servicio
builder.Services.RegisterDependencies();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();




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
