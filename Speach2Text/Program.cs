using Speach2Text.Interfaces;
using Speach2Text.Services;
using Speach2Text.Validation;
using FastEndpoints;
using FastEndpoints.Swagger;
using Speach2Text.Providers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();

RegisterServices(builder);
RegisterLogger(builder.Configuration);

var app = builder.Build();


app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());
app.UseHttpsRedirection();

app.UseMiddleware<ValidationExceptionMiddleware>();

//app.UseFastEndpoints(x => 
//{

//    x.ErrorResponseBuilder = (failures, _) =>
//    {
//        return new ValidationFailureResponse
//        {
//            Errors = failures.Select(y => y.ErrorMessage).ToList()
//        };
//    };
//});


//app.Logger.LogInformation("The application started");


app.Run();

void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services.AddSingleton<ISpeechToTextService, SpeechToTextService>();
    builder.Services.AddSingleton<IWhisperProvider, WhisperProvider>();
}

void RegisterLogger(ConfigurationManager configuration)
{
    builder.Logging.ClearProviders();
    // Serilog configuration		
    var logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File(configuration.GetSection("LogsPath").Value, rollingInterval: RollingInterval.Day)
        .CreateLogger();
    // Register Serilog
    builder.Logging.AddSerilog(logger);
}