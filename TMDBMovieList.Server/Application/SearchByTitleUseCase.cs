using Newtonsoft.Json.Linq;
using RestSharp;
using TMDBMovieList.Server.Controllers;
using TMDBMovieList.Server.Enitites;

namespace TMDBMovieList.Server.Application
{
    public class SearchByTitleUseCase
    {
        public IEnumerable<Filme> Execute(string movieTitle, string bearer)
        {
            var options = new RestClientOptions($"https://api.themoviedb.org/3/search/movie?query={movieTitle}&include_adult=false&language=pt-BR&page=1");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {bearer}");
            var response = client.Get(request);

            var json = response.Content != null ? response.Content : string.Empty;
            var jobject = json != string.Empty ? JObject.Parse(json) : null;
            var filmResults = jobject["results"];
            List<Filme> results = [];

            foreach (var film in filmResults)
            {
                results.Add(new Filme
                {
                    Id = (int)film["id"],
                    Title = (string)film["title"],
                    Original_language = (string)film["original_language"],
                    Original_title = (string)film["original_title"],
                    Popularity = (int)film["popularity"],
                    Release_date = MyExtensions.ParseDateTime((string)film["release_date"]),
                    Vote_average = (double)film["vote_average"],
                    Vote_count = (int)film["vote_count"],
                    Poster_path = $"https://image.tmdb.org/t/p/w92/{(string)film["poster_path"]}"
                });
            }

            return results;   
        }

        private void Validate(ShortFilme request, TMDBDbContext dbContext)
        {

        }
    }
}
