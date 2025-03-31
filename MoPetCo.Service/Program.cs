using MoPetCo.BusinessLogic;
using MoPetCo.BusinessLogic.Extensions;
using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.DataAccess;
using MoPetCo.Extensions;
using MoPetCo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuring services for the application
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);   
builder.Services.AddMoPetCoServices();
builder.Services.AddHttpClient();

builder.Services.AddScoped<CustomValuesConfiguration>();
builder.Services.AddScoped<IServicio, MoPetCo.BusinessLogic.Servicio>();
builder.Services.AddScoped<IContacto, MoPetCo.BusinessLogic.Contacto>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<FileHelper>();
builder.Services.AddScoped<IMedia, MoPetCo.BusinessLogic.Media>();

// CORS: Permitir peticiones desde Vite (localhost:5173)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();
