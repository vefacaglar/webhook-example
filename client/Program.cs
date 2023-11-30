const string server = "http://localhost:5100";
const string callback = "http://localhost:5198/wh/item/new";
const string topic = "item.new";

var client = new HttpClient();

Console.WriteLine($"subscribing to topic {topic} with callback {callback}");
await client.PostAsJsonAsync(server + "/subscribe", new { topic, callback });

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/wh/item/new", (object payload, ILogger<Program> logger) => {
    logger.LogInformation("received payload {payload}", payload);
});

app.Run();
