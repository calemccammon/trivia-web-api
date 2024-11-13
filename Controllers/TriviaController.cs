
using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TriviaApi.Model;

namespace TriviaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TriviaController(IHttpClientFactory factory) : ControllerBase
{
    private readonly IHttpClientFactory _factory = factory;

    [HttpGet("GetQuestion")]
    [Produces("application/json")]
    public async Task<TriviaList> GetQuestion(
        TriviaDifficulty? difficulty,
        TriviaCategory? category,
        TriviaType? type,
        [Range(1, 50)] int amount = 1
    )
    {
        var client = _factory.CreateClient("trivia");

        var query = HttpUtility.ParseQueryString(string.Empty);
        query.Add("amount", amount.ToString());

        if (difficulty != null)
        {
            query.Add("difficulty", difficulty.ToString());
        }

        if (category != null)
        {
            query.Add("category", ((int) category).ToString());
        }

        if (type != null)
        {
            query.Add("type", type.ToString());
        }
        
        var response = await client.GetAsync("api.php?" + query.ToString());
        response.EnsureSuccessStatusCode();

        string body = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<TriviaList>(body) ?? 
            throw new HttpRequestException("No questions received", null, 
                System.Net.HttpStatusCode.InternalServerError);
    }
}
