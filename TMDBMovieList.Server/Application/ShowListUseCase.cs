using Newtonsoft.Json.Linq;
using RestSharp;
using TMDBMovieList.Server.Controllers;
using TMDBMovieList.Server.Enitites;

namespace TMDBMovieList.Server.Application
{
    public class ShowListUseCase
    {
        private readonly TMDBDbContext _dbContext;
        public ShowListUseCase()
        {
            _dbContext = new TMDBDbContext();
        }
        public IEnumerable<Filme> Execute()
        {
            Console.WriteLine("in");

            var filmes = _dbContext.Filmes.ToList();

            List<Filme> results = [];

            foreach (var filme in filmes)
            {
                {
                    results.Add(new Filme
                    {
                        Id = filme.Id,
                        Title = filme.Title,
                        Original_language = filme.Original_language,
                        Original_title = filme.Original_title,
                        Popularity = filme.Popularity,
                        Release_date = filme.Release_date,
                        Vote_average = filme.Vote_average,
                        Vote_count = filme.Vote_count,
                        Poster_path = $"https://image.tmdb.org/t/p/w92/{filme.Poster_path}"
                    });
                }
            }

            return results;
        }
    }
}

/*var options = new RestClientOptions($"https://api.themoviedb.org/3/movie/{filme.Id}?language=pt-BR");
var client = new RestClient(options);
var request = new RestRequest("");
request.AddHeader("accept", "application/json");
request.AddHeader("Authorization", $"Bearer {bearer}");
var response = client.Get(request);

var json = response.Content != null ? response.Content : string.Empty;
var filme = json != string.Empty ? JObject.Parse(json) : null;

 foreach (var filme in filmes)
            {
                {
                    results.Add(new Filme
                    {
                        Id = (int)filme["id"],
                        Title = (string)filme["title"],
                        Original_language = (string)filme["original_language"],
                        Original_title = (string)filme["original_title"],
                        Popularity = (int)filme["popularity"],
                        Release_date = MyExtensions.ParseDateTime((string)filme["release_date"]),
                        Vote_average = (double)filme["vote_average"],
                        Vote_count = (int)filme["vote_count"],
                        Poster_path = $"https://image.tmdb.org/t/p/w92/{(string)filme["poster_path"]}"
                    });
                }
            }*/

