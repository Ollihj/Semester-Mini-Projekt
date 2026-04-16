using System.Net.Http.Json;
using Core.Models;
using BlazorApp4.Pages;

namespace BlazorApp4.Service;

public class LoginService
{
    private readonly HttpClient _client;

    public LoginService(HttpClient client)
    {
        _client = client;
    }

    public async Task<bruger?> ValidLogin(string name, string password)
    {
        try
        {
            var response = await _client.GetAsync($"{Config.ServerUrl}/api/bruger/login?navn={name}&password={password}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bruger>();
            }
            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<bruger?> Register(string name, string password)
    {
        try
        {
            var newUser = new bruger { Navn = name, Password = password, brugerID = Guid.NewGuid().ToString() };
            var response = await _client.PostAsJsonAsync($"{Config.ServerUrl}/api/bruger/register", newUser);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bruger>();
            }
            return null;
        }
        catch
        {
            return null;
        }
    }
}
