using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace StreamVault.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public Credit Credits { get; set; }

    }
}
