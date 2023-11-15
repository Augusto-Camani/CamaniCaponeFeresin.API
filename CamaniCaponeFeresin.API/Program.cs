using CamaniCaponeFeresin.API.Data.Repositories.Implementations;
using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.DBContext;
using CamaniCaponeFeresin.API.Services.Implementations;
using CamaniCaponeFeresin.API.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
//Esto hay que agregarlo para que no haga referencias circulares al serializar.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Hacemos la inyecci�n de dependencia de nuestro contexto para que utilice X base de datos.
//Arrow function para indicar que las "options" sean del tipo de la base de datos que queremos manejar.
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlite(builder.Configuration["ConnectionStrings:SQLiteConnection"]));

//Construimos un AutoMapper, para que cuando pasemos DTO, se mapeen sus datos correctamente en la Base de Datos de su respectiva ENTITY.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Creamos una regi�n para hacer todas las inyecciones de dependencias de los Repositorios del patr�n Repository.
//El IRepository y el Repository no se inyectan ya que sus hijos heredan de �l y pisan la Dependency Inyaction.
#region Repositories
builder.Services.AddScoped < IProductRepository, ProductRepository >(); 
builder.Services.AddScoped<IUserRepository, UserRepository >();
builder.Services.AddScoped<ISaleRepository, SaleRepository >();
builder.Services.AddScoped<ISaleLineRepository, SaleLineRepository >();
#endregion

//Creamos una regi�n en donde realizamos todas las inyecciones de dependencia de los Servicios.
#region Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISaleService, SaleService >();
builder.Services.AddScoped<ISaleLineService, SaleLineService >();
#endregion

//Construye la aplicaci�n, en base a todos los par�metros, reglas y �rdenes que realizamos arriba.
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
