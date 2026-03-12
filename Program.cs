using Back.Interview.Application.UseCases;
using Back.Interview.Domain.Repositories;
using Back.Interview.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar dependências
builder.Services.AddScoped<IDataInterviewRepository, DataInterviewRepository>();
builder.Services.AddScoped<IGetInterviewUseCase, GetInterviewUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();