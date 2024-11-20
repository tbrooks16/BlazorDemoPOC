using BlazorDemoPOC.Client.Shared.ClientServices;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMudServices();
var test = builder.Configuration["FrontendUrl"];
Console.WriteLine(test);
Console.WriteLine(builder.Configuration);
builder.Services.AddScoped(sp => new HttpClient{BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:5002")}); // TODO create frontendurl in app config.
builder.Services.AddScoped<ClientPersonService>();

await builder.Build().RunAsync();
