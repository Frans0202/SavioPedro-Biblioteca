using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Profiles;
using WebApplication1.Services;


var builder = WebApplication.CreateBuilder(args);

// Configuração do Entity Framework Core com MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AutorService>();
builder.Services.AddScoped<LivroService>();
builder.Services.AddScoped<EmprestimoService>();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<PenalidadeService>();

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

// Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "SavioPedro Biblioteca API",
        Version = "v1",
        Description = "API para gerenciamento de uma biblioteca"
    });
});

var app = builder.Build();

// Configuração do ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();