using System;
using System.Net.Http.Json;
using BlazorDemoPOC.Models;

namespace BlazorDemoPOC.Client.Shared.ClientServices;

public class ClientPersonService(HttpClient http, IConfiguration config)
{
    public async Task PostPerson(Person person){

        // When Client backend url is 7256 and running through Visual Studio (7256). It works.
        // TODO How do I get it to work when using dotnet watch as well? Dotnet watch runs on 5216
        var uri = config.GetValue<string>("BackendUrl") ?? "https://localhost:5216";
        Console.WriteLine(config.GetValue<string>("FrontendUrl"));
        Console.WriteLine(uri);
        await http.PostAsJsonAsync($"{uri}/api/v1/person", person);
    } 
}
