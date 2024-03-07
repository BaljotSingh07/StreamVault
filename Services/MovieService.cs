using StreamVault.Models;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace StreamVault.Services
{
    public class MovieService
    {
        public async Task<ICollection<Movie>> GetMovieCollectionByUri(string uri)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZjBkOTI0MGZmMTRjNThlNTFhNTc2MTUzZjEzMDYxYSIsInN1YiI6IjY1ZDE0MjNhZGI3MmMwMDE4NjM4YTFjZCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.6EimwIeJduQ6v5zFItUuINxkW1bKaLUSay_mKDkj8AM");
            var response = await client.GetStringAsync(uri);
            //api sometimes return an empty release date, replace with for now random 
            string invalidReleaseDatePattern = "\"\"";
            response = Regex.Replace(response, invalidReleaseDatePattern, "\"2001-10-12\"");
            TmdbApiResponse result = JsonSerializer.Deserialize<TmdbApiResponse>(response, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            });

            return result.Results;
        }

        public async Task<ICollection<Movie>> GetTrendingWeekAsync()
        {
            return await GetMovieCollectionByUri("https://api.themoviedb.org/3/trending/movie/day?language=en-US");
        }

        public async Task<ICollection<Movie>> GetTopRatedAsync()
        {
            return await GetMovieCollectionByUri("https://api.themoviedb.org/3/movie/top_rated?language=en-US&page=1");
        }

        public async Task<ICollection<Movie>> GetNowPlayingAsync()
        {
            return await GetMovieCollectionByUri("https://api.themoviedb.org/3/movie/now_playing?language=en-US&page=1");
        }

        public async Task<ICollection<Movie>> DiscoverAsync(DiscoverQuery filters)
        {
            string uri = $"https://api.themoviedb.org/3/discover/movie?include_adult=false&include_video=false&language=en-US&{filters}";
            return await GetMovieCollectionByUri(uri);

        }

        public async Task<Movie> GetMovie(int Id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZjBkOTI0MGZmMTRjNThlNTFhNTc2MTUzZjEzMDYxYSIsInN1YiI6IjY1ZDE0MjNhZGI3MmMwMDE4NjM4YTFjZCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.6EimwIeJduQ6v5zFItUuINxkW1bKaLUSay_mKDkj8AM");
            var response = await client.GetStringAsync($"https://api.themoviedb.org/3/movie/{Id}?append_to_response=credits&language=en-US");

            Movie result = JsonSerializer.Deserialize<Movie>(response, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            });

            return result;
        }

        public async Task<TmdbGenreResponse> GetMovieGenres()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZjBkOTI0MGZmMTRjNThlNTFhNTc2MTUzZjEzMDYxYSIsInN1YiI6IjY1ZDE0MjNhZGI3MmMwMDE4NjM4YTFjZCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.6EimwIeJduQ6v5zFItUuINxkW1bKaLUSay_mKDkj8AM");
            var response = await client.GetStringAsync("https://api.themoviedb.org/3/genre/movie/list?language=en");

            TmdbGenreResponse result = JsonSerializer.Deserialize<TmdbGenreResponse>(response, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            });

            return result;
        }
    }
}
