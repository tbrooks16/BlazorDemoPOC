using BlazorDemoPOC.Client.Shared;
using BlazorDemoPOC.Components;
using BlazorDemoPOC.Data;
using BlazorDemoPOC.Models;
using BlazorDemoPOC.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);
// builder.WebHost.UseUrls("http://localhost:7256");

var backendUrl = builder.Configuration["BackendUrl"];
var frontendUrl = builder.Configuration["FrontendUrl"];
builder.Services.AddCors(options => options.AddPolicy("wasm", policy => policy.WithOrigins(
    [backendUrl ?? "https://localhost:5001", frontendUrl ?? "https://localhost:5002"])
    .AllowAnyMethod()
    .AllowAnyHeader()
    ));

builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddInteractiveWebAssemblyComponents();

var connectionString = builder.Configuration.GetConnectionString("database") ?? throw new InvalidOperationException("Connection string 'database' not found");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
builder.Services.AddMudServices();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddHttpClient();

var app = builder.Build();

app.UseCors("wasm");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

var person = app.MapGroup("/api/v1/person");

person.MapPost("/", CreatePerson);
person.MapGet("/", GetPerson);


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode().AddInteractiveWebAssemblyRenderMode().AddAdditionalAssemblies(typeof(MyButton).Assembly);



app.Run();

static async Task<bool> CreatePerson(Person person, IPersonRepository personRepository){
    return await personRepository.CreatePerson(person);
}

static async Task<bool> GetPerson(){
    return await Task.FromResult(true);
}
