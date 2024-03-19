
using BL;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<BLManager>();

builder.Services.AddControllers();

//var provider = builder.Services.BuildServiceProvider();
//var configuration = provider.GetRequiredService<IConfiguration>();

//builder.Services.AddCors(options =>
//{
//    var frontend_url = configuration.GetValue<string>("frontend_url");
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.WithOrigins(frontend_url).AllowAnyMethod().AllowAnyHeader();
//    });
//});

var app = builder.Build();

app.MapControllers(); 

//app.UseHttpsRedirection();

//app.UseCors();

app.Run();

