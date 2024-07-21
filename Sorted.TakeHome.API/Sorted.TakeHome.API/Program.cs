using Sorted.TakeHome.API.Readings;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICollectRainfallReadings, RainfallReader>();

var apiBaseUrl = builder.Configuration.GetSection("Refit:Api:BaseUrl").Get<string>();
builder.Services.AddRefitClient<IRetrieveReadings>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl));


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
