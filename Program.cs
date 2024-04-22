using AspNetCoreIocExample.Dependencies;
using AspNetCoreIocExample.Dependencies.Deep;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Uncomment this and the application will throw an exception
// builder.Services.AddSingleton<BadSingletonRoot>();
builder.Services.AddSingleton<SingletonRoot>();
builder.Services.AddSingleton<SingletonChild>();
builder.Services.AddSingleton<SingletonDependency>();

// Uncomment this and the application will throw an exception
// builder.Services.AddScoped<BadScopedRoot>();
builder.Services.AddScoped<ScopedRoot>();
builder.Services.AddScoped<ScopedChild>();
builder.Services.AddScoped<ScopedDependency>();

builder.Services.AddTransient<TransientRoot>();
builder.Services.AddTransient<TransientChild>();
builder.Services.AddTransient<TransientDependency>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet(
    "/singleton-root",
    (SingletonRoot singletonRoot) =>
    {
        singletonRoot.Execute();

        return Results.Ok();
    });

app.MapGet(
    "/scoped-root",
    (ScopedRoot scopedRoot) =>
    {
        scopedRoot.Execute();

        return Results.Ok();
    });

app.MapGet(
    "/transient-root",
    (TransientRoot transientRoot) =>
    {
        transientRoot.Execute();

        return Results.Ok();
    });

app.Run();
