using System.Net.Http.Json;
using Core.Models;
using BlazorApp4.Pages;

namespace BlazorApp4.Service;

public class BrugerServiceHttp : IBrugerService
{
    private readonly HttpClient client;

    public BrugerServiceHttp(HttpClient client)
    {
        this.client = client;
    }

    public async Task<List<bruger>> GetAll()
    {
        var data = await client.GetFromJsonAsync<List<bruger>>($"{Config.ServerUrl}/api/bruger");
        return data ?? new List<bruger>();
    }

    public async Task<bruger?> GetById(string id)
    {
        return await client.GetFromJsonAsync<bruger>($"{Config.ServerUrl}/api/bruger/{id}");
    }
}
