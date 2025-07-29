using BackendAPI.Data;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configConn = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString = configConn == "UseAzureEnv"
    ? Environment.GetEnvironmentVariable("AZURE_DB_CONNECTION")
    : configConn;

builder.Services.AddDbContext<AppDbContext>(options =>options.UseNpgsql(connectionString));
builder.Services.AddScoped<ISlotService, SlotService>();
builder.Services.AddControllers(); 
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapControllers(); 

app.Run();


