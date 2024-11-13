using Newtonsoft.Json;

namespace TriviaApi.Model;

public class TriviaList
{
    [JsonProperty("response_code")]
    public int ResponseCode { get; set; }

    [JsonProperty("results")]
    public required Result[] Results { get; set; }

    public class Result
    {
        [JsonProperty("type")]
        public required TriviaType Type { get; set; }

        [JsonProperty("difficulty")]
        public required TriviaDifficulty Difficulty { get; set; }

        [JsonProperty("category")]
        public required string Category { get; set; }

        [JsonProperty("question")]
        public required string Question { get; set; }

        [JsonProperty("correct_answer")]
        public required string CorrectAnswer { get; set; }

        [JsonProperty("incorrect_answers")]
        public required string[] IncorrectAnswers { get; set; }
        
    }
}