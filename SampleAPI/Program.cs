using Logging;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entity;
using Saga;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SampleApiDbContext>(options => options.UseInMemoryDatabase(databaseName: "SampleDB"));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
AutomapperProfile.AutomapperConfig(builder.Services, builder.Configuration);
builder.Services.AddScoped<ILoggerHelper, LoggerHelper>();
builder.Services.AddScoped<IOrderSaga, OrderSaga>();
builder.Services.AddScoped<ICreateOrderSaga, CreateOrderSaga>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

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
