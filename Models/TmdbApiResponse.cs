namespace StreamVault.Models
{
    public class TmdbApiResponse
    {
        public int Page { get; set; }
        public ICollection<Movie> Results { get; set; }
    }
}
