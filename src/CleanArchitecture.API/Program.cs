using CleanArchitecture.Application.DependencyInjection.Extensions;
using CleanArchitecture.Pesistence.DependencyInjection.Extensions;
using CleanArchitecture.Pesistence.DependencyInjection.Options;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();

//Log.Logger = new LoggerConfiguration().ReadFrom
//                 .Configuration(builder.Configuration)
//                 .CreateLogger();   

// Add Application layer servicecollectionextensions

builder.Services.AddConfigureMediatR();
builder.Services.ConfigureSqlServerRetryOptions(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));
builder.Services.AddSqlConfiguration();
builder.Services.AddConfigurationAutoMapper();
builder.Services.AddRepositoryBaseConfiguration();


// API
builder
    .Services
    .AddControllers()
    .AddApplicationPart(CleanArchitecture.Presentation.AssemblyReference.Assembly);





var app = builder.Build();

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
