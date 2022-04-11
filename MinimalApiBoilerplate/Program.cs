var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointDefinitions(builder.Configuration, typeof(HelloEndpoint));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DI
builder.Services.Register(builder.Configuration);

var app = builder.Build();

// map our endpoints to the app & configure middleware
app.UseEndpointDefinitions();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


app.Run();
