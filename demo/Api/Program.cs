using System.Text.Json.Serialization;
using Api.Contract;
using Api.Endpoint;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddOpenApi()
    .ConfigureHttpJsonOptions(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.MapGet("/union/path-parameter/{identifier}", 
    (Identifier identifier) => new GetUnionPathParameterEndpoint().Handle(new GetUnionPathParameterRequest(identifier)));
app.MapPost("/union/body/{identifier}",
    (Identifier identifier, PostUnionBody body) => new PostUnionBodyEndpoint().Handle(new PostUnionBodyRequest(identifier, body)));

app.Run();