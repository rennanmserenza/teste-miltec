using ProjetoAnunciosMilTec.API.Archietecture;

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

app.Run();