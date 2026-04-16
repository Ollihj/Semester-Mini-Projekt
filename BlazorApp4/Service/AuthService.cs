using Microsoft.JSInterop;
using Core.Models;
using System.Text.Json;

namespace BlazorApp4.Service;

public class AuthService
{
    private readonly IJSRuntime _js;

    public AuthService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task GemBruger(bruger bruger)
    {
        var json = JsonSerializer.Serialize(bruger);
        await _js.InvokeVoidAsync("sessionStorage.setItem", "bruger", json);
    }

    public async Task<bruger?> HentBruger()
    {
        var json = await _js.InvokeAsync<string>("sessionStorage.getItem", "bruger");
        if (string.IsNullOrEmpty(json)) return null;
        return JsonSerializer.Deserialize<bruger>(json);
    }

    public async Task LogUd()
    {
        await _js.InvokeVoidAsync("sessionStorage.removeItem", "bruger");
    }
}
