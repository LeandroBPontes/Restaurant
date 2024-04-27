using Microsoft.OpenApi.Models;
using RestaurantApi.Interfaces;
using RestaurantApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRestaurantBuilderReturnService, RestaurantBuilderReturnService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant API", Version = "v1" });
});

builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.UseCors(policy => policy
        .AllowAnyOrigin() // Permitir solicitações de qualquer origem
        .AllowAnyMethod() // Permitir qualquer método (GET, POST, etc.)
        .AllowAnyHeader() // Permitir qualquer cabeçalho
);


app.UseRouting();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API v1");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

app.Run();