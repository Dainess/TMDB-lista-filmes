using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using TMDBMovieList.Server.Enitites;

namespace TMDBMovieList.Server.Application
{
    public class GetFilmeUseCaseDEPRECATED
    {
        [HttpGet(Name = "GetFilme")]
        public IEnumerable<Filme> Get(string bearer)
        {
            string filme = "matrix";

            var options = new RestClientOptions($"https://api.themoviedb.org/3/search/movie?query={filme}&include_adult=false&language=pt-BR&page=1");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {bearer}");
            var response = client.Get(request);

            //Console.WriteLine("{0}", response.Content);

            var json = response.Content != null ? response.Content : string.Empty;
            var jobject = json != string.Empty ? JObject.Parse(json) : null;
            var title = (string)jobject["results"][0]["title"];
            Console.WriteLine(title);

            return [new Filme { Id = -1, Title = title }];
        }
    }
}
