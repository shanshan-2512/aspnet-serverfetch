using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web_api_hello.Models;

namespace web_api_hello.Pages;

public class IndexModel : PageModel
{

    private ILogger<IndexModel> _logger;
    private readonly HttpClient httpClient = new HttpClient();

    public RandomUsers UsersContainer { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        UsersContainer = new RandomUsers();
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        _logger.Log(LogLevel.Information, "out");
        var respondeMessage = await httpClient.GetAsync("https://www.randomuser.me/api/?results=5");

        if (respondeMessage.IsSuccessStatusCode)
        {

            var dataJson = await respondeMessage.Content.ReadAsStreamAsync();

            UsersContainer = await JsonSerializer.DeserializeAsync<RandomUsers>(
            dataJson,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            ) ?? UsersContainer;
        }

        return Page();

    }

}