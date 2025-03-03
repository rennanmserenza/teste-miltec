using ProjetoAnunciosMilTec.API.Archietecture;
using ProjetoAnunciosMilTec.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureBuilder();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapEndPoints();

app.Run();