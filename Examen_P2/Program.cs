using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Activamos swagger para la previsualizaci�n de los EndPoints
builder.Services.AddSwaggerGen();


// 
var connectionString = builder.Configuration.GetConnectionString("cadenaSQL");
builder.Services.AddDbContext<Examen_P2.Models.ParcialDbContext>(options => options.UseSqlServer(connectionString));    


// Definimos la nueva pol�tica de CORS para que la API sea accesible desde cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaApi", app =>
    {
        app.AllowAnyOrigin() // Permite cualquier origen
            .AllowAnyMethod() // Permite cualquier m�todo HTTP (GET, POST, PUT, DELETE, etc.)
            .AllowAnyHeader(); // Permite cualquier encabezado
    });
});


// 
var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Activamos la n�eva pol�tica
app.UseCors("NuevaApi");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
