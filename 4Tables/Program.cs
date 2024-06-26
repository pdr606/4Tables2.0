using _4Tables.Extensions;
using _4Tables2._0.Infra.Data.DbConfig;
using _4Tables2._0.Infra.Bootstrap;
using System.Text.Json.Serialization;
using _4Tables2._0.IoC.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddJsonConfiguration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddService();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseCors(x => x
    .SetIsOriginAllowed(orign => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
}
app.RunMigrations();
app.Run();
