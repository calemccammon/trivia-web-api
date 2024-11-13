using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TriviaApi.Model;

public class TriviaRequest
{
    [JsonProperty("category")]
    public TriviaDifficulty? Difficulty { get; set; }

    [JsonProperty("amount")]
    [Range(1, 50)]
    public int Amount { get; set; }

}