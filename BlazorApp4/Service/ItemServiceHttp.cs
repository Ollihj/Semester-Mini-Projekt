using System.Net.Http.Json;
using Core.Models;
using BlazorApp4.Pages;
using BlazorApp4.Service;

public class ItemServiceHttp : IItemService
{
    private HttpClient client;

    public ItemServiceHttp(HttpClient client)
    {
        this.client = client;
    }

    public async Task<List<annoncer>> GetAll()
    {
        var data = await client.GetFromJsonAsync<List<annoncer>>($"{Config.ServerUrl}/api/annoncer");
        return data ?? new List<annoncer>();
    }

    public async Task<annoncer?> GetById(string id)
    {
        return await client.GetFromJsonAsync<annoncer>($"{Config.ServerUrl}/api/annoncer/{id}");
    }

    public async Task Add(annoncer item)
    {
        await client.PostAsJsonAsync($"{Config.ServerUrl}/api/annoncer", item);
    }

    public async Task Update(annoncer item)
    {
        await client.PutAsJsonAsync($"{Config.ServerUrl}/api/annoncer", item);
    }

    public async Task DeleteById(string id)
    {
        await client.DeleteAsync($"{Config.ServerUrl}/api/annoncer/{id}");
    }
}
