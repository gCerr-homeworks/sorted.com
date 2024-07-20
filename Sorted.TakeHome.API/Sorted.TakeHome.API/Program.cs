using Sorted.TakeHome.API.Readings;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICollectRainfallReadings, RainfallReader>();
builder.Services.AddRefitClient<IRetrieveReadings>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://environment.data.gov.uk/flood-monitoring"));


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
