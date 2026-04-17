using System.Net.Http.Json;
using Core.Models;

namespace BlazorApp4.Service;

public class KøbsanmodningerServiceHttp : IKøbsanmodningerService
{
    private readonly HttpClient client;

    public KøbsanmodningerServiceHttp(HttpClient client)
    {
        this.client = client;
    }

    public async Task<List<købsanmodninger>> GetAll()
    {
        return await client.GetFromJsonAsync<List<købsanmodninger>>(
                   "api/koebsanmodning")
               ?? new List<købsanmodninger>();
    }

    public async Task<købsanmodninger?> GetById(string id)
    {
        return await client.GetFromJsonAsync<købsanmodninger>(
            $"api/koebsanmodning/{id}");
    }

    public async Task Add(købsanmodninger anmodning)
    {
        var response =
            await client.PostAsJsonAsync("api/koebsanmodning", anmodning);

        response.EnsureSuccessStatusCode();
    }

    public async Task Update(købsanmodninger anmodning)
    {
        var response =
            await client.PutAsJsonAsync("api/koebsanmodning", anmodning);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteById(string id)
    {
        var response =
            await client.DeleteAsync($"api/koebsanmodning/{id}");

        response.EnsureSuccessStatusCode();
    }
}
