using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => 
        options.SerializerSettings.Converters.Add(new StringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc(
            "v1",
            new OpenApiInfo {
                Title = "Trivia API",
                Version = "v1",
                Description = "Demo webservice for fetching trivia questions, made possible with https://opentdb.com/."
            }
        );
        var filePath = Path.Combine(System.AppContext.BaseDirectory, "TriviaApi.xml");
        c.IncludeXmlComments(filePath);
    }
).AddSwaggerGenNewtonsoftSupport();

builder.Services.AddHttpClient("trivia", c =>
{
    c.BaseAddress = new Uri("https://opentdb.com/");
    c.Timeout = TimeSpan.FromSeconds(15);
    c.DefaultRequestHeaders.Add("accept", "application/json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            options.ConfigObject = new ConfigObject
            {
                ShowCommonExtensions = true
            };
        }
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
