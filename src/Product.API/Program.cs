using Microsoft.OpenApi.Models;
using Product.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddApplicationServices();
builder.Services.AddApplicationDbContext(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{ c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "Product API v1",
    Version = "v1",
    Description = "Product API Version 1.",
    Contact = new OpenApiContact
    {
        Name = "Product API by Zahid Tanveer",
    },

     });
    var filePath = Path.Combine(AppContext.BaseDirectory, "Product.API.xml");
    c.IncludeXmlComments(filePath);
});

var app = builder.Build();
app.Services.Seeder();
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
