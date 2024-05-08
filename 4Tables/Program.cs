using _4Tables.Extensions;
using _4Tables2._0.Infra.Data.DbConfig;
using _4Tables2._0.Infra.Bootstrap;
using System.Text.Json.Serialization;
using _4Tables2._0.IoC.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddService();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
}
app.RunMigrations();
app.Run();
