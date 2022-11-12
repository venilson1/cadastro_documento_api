using cadastro_documento_api.Source.Core.Interfaces.Repositories;
using cadastro_documento_api.Source.Core.Interfaces.Services;
using cadastro_documento_api.Source.Infraestructure.Contexts;
using cadastro_documento_api.Source.Infraestructure.Repositories;
using cadastro_documento_api.Source.Infraestructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDocumentoRepository, DocumentoRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddDbContext<CadastroDocumentosContex>(options => options.UseLazyLoadingProxies().UseMySql("server=localhost;database=homedb;user=root;password=root", ServerVersion.Parse("8.0.31-mysql")));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

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
