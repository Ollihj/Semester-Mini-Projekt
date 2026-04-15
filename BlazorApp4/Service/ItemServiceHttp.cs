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
        var data = await client.GetFromJsonAsync<List<annoncer>>($"{Config.ServerUrl}/Home");
        return data ?? new List<annoncer>();
    }

    public async Task<annoncer?> GetById(int id)
    {
        return await client.GetFromJsonAsync<annoncer>($"{Config.ServerUrl}/Home/{id}");
    }

    public async Task Add(annoncer item)
    {
        await client.PostAsJsonAsync($"{Config.ServerUrl}/Home", item);
    }

    public async Task Update(annoncer item)
    {
        await client.PutAsJsonAsync($"{Config.ServerUrl}/Home/{item.annonceId}", item);
    }

    public async Task DeleteById(int id)
    {
        await client.DeleteAsync($"{Config.ServerUrl}/Home/{id}");
    }
}
