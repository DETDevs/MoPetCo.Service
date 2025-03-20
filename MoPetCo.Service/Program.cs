using MoPetCo.BusinessLogic;
using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.DataAccess;
using MoPetCo.DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuring services for the application
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IConnectionManager, ConnectionManager>();
builder.Services.AddScoped<MoPetCo.DataAccess.Interfaces.IServicio, MoPetCo.DataAccess.Servicio>();
builder.Services.AddScoped<MoPetCo.BusinessLogic.Interfaces.IServicio, MoPetCo.BusinessLogic.Servicio>();
builder.Services.AddScoped<MoPetCo.DataAccess.Interfaces.IContacto, MoPetCo.DataAccess.Contacto>();
builder.Services.AddScoped<MoPetCo.BusinessLogic.Interfaces.IContacto, MoPetCo.BusinessLogic.Contacto>();
builder.Services.AddScoped<MoPetCo.Extensions.EmailService>();

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

app.Run();
