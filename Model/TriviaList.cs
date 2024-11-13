using Newtonsoft.Json;

namespace TriviaApi.Model;

/// <summary>
/// Data model for the list of questions
/// </summary>
public class TriviaList
{
    /// <summary>
    /// Response code of the fetching
    /// </summary>
    [JsonProperty("response_code")]
    public int ResponseCode { get; set; }

    /// <summary>
    /// List of questions
    /// </summary>
    [JsonProperty("results")]
    public required Result[] Results { get; set; }

    /// <summary>
    /// Data model for trivia questions
    /// </summary>
    public class Result
    {
        /// <summary>
        /// The enumerated type of the question
        /// </summary>
        [JsonProperty("type")]
        public required TriviaType Type { get; set; }

        /// <summary>
        /// The enumerated difficulty of the question
        /// </summary>
        [JsonProperty("difficulty")]
        public required TriviaDifficulty Difficulty { get; set; }

        /// <summary>
        /// The category of the question
        /// </summary>
        [JsonProperty("category")]
        public required string Category { get; set; }

        /// <summary>
        /// The question the user must answer
        /// </summary>
        [JsonProperty("question")]
        public required string Question { get; set; }

        /// <summary>
        /// The correct answer for the question
        /// </summary>
        [JsonProperty("correct_answer")]
        public required string CorrectAnswer { get; set; }

        /// <summary>
        /// A list of incorrect answers, which may be true or false
        /// in the case of binary questions or which may be a list of multiple
        /// choices
        /// </summary>
        [JsonProperty("incorrect_answers")]
        public required string[] IncorrectAnswers { get; set; }
        
    }
}