using Microsoft.AspNetCore.Mvc;
using TMDBMovieList.Server.Enitites;
using RestSharp;
using Newtonsoft.Json.Linq;
using TMDBMovieList.Server.Application;
using TMDBMovieList.Server.Exceptions;
using System.Xml.Linq;

namespace TMDBMovieList.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TMDBController : Controller
    {
        [HttpGet]
        [Route("{movieTitle}")]
        /*[ProducesResponseType(typeof(ResponseFullDonorJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]*/
        public IEnumerable<Filme> SearchByTitle([FromRoute] string movieTitle, [FromQuery] string bearer)
        {
            var useCase = new SearchByTitleUseCase();
            var results = useCase.Execute(movieTitle, bearer);
            return results;
        }

        [HttpPost]
        /*[ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]*/
        public IActionResult Register([FromBody] Filme request)
        {
            try
            {
                var useCase = new RegisterFilmUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch (TMDBException ex)
            {
                return BadRequest(new { errors = ex.GetErrorMessages()});
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ExceptionMessages.UNKNOWN_ERROR_MESSAGE);
            }
        }

        [HttpGet]
        [Route("getlist/{listName}")]
        public IEnumerable<Filme> ShowList()
        {
            Console.WriteLine("inController");
            var useCase = new ShowListUseCase();
            var results = useCase.Execute();
            return results;
        }

        [HttpDelete]
        [Route("{id}")]
        /*[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]*/
        public IActionResult DeleteById([FromRoute] int id)
        {
            var useCase = new DeleteFilmByIdUseCase();
            useCase.Execute(id);
            return NoContent();
        }

        [HttpGet]
        [Route("getlist/shareable")]
        public ContentResult Favorites([FromQuery] string[] favorite)
        {
            var html = CreateFavoriteEndpoint(favorite);

            return base.Content(html, "text/html");
        }

        private string CreateFavoriteEndpoint(string[] favorite)
        {
            var html = "<p>List of your favorites: </p>";
            foreach (string item in favorite)
            {
                var subs = item.Split(' ');
                string link = $"https://www.themoviedb.org/movie/{subs[0]}";
                string title = subs[1].Replace('_', ' ');
                html += $"<a href={link}>{title}</a><br>";
            }
            //receber a lista de favoritos e adicionar tags a para cada um dos links do tmdb
            //na vdd o react lá vai só gerar o link com a query, esse link que vai acionar a API
            //html = html.Replace("{{favorite}}", favorite);
            return html;
        }
    }

    public static class MyExtensions
    {
        public static DateTime? ParseDateTime(this string str)
        {
            DateTime k;
            if (DateTime.TryParse(str, out k))
                return k;
            return null;
        }
    }
}
