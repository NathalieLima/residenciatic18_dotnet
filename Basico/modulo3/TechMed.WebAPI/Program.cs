using Model.TechMed.WebAPI;

var builder = WebApplication.CreateBuilder(args); // Criação da aplicação

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<OpeningTime>(builder.Configuration.GetSection("OpeningTime"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); //lê todos os controllers da API e transforma lá

app.Run();
