using CamaniCaponeFeresin.API.Data.Repositories.Implementations;
using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.DBContext;
using CamaniCaponeFeresin.API.Services.Implementations;
using CamaniCaponeFeresin.API.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Hacemos la inyección de dependencia de nuestro contexto para que utilice X base de datos.
//Arrow function para indicar que las "options" sean del tipo de la base de datos que queremos manejar.
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlite(builder.Configuration["ConnectionStrings:SQLiteConnection"]));

//Construimos un AutoMapper, para que cuando pasemos DTO, se mapeen sus datos correctamente en la Base de Datos de su respectiva ENTITY.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Creamos una región para hacer todas las inyecciones de dependencias de los Repositorios del patrón Repository.
//El IRepository y el Repository no se inyectan ya que sus hijos heredan de él y pisan la Dependency Inyaction.
#region Repositories
builder.Services.AddScoped < IProductRepository, ProductRepository >(); 
builder.Services.AddScoped<IUserRepository, UserRepository >();
#endregion

//Creamos una región en donde realizamos todas las inyecciones de dependencia de los Servicios.
#region Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion

//Construye la aplicación, en base a todos los parámetros, reglas y órdenes que realizamos arriba.
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
