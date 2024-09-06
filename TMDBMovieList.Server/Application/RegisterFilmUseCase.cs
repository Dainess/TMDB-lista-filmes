using TMDBMovieList.Server.Enitites;
using TMDBMovieList.Server.Exceptions;

namespace TMDBMovieList.Server.Application
{
    public class RegisterFilmUseCase
    {
        private readonly TMDBDbContext _dbContext;
        public RegisterFilmUseCase()
        {
            _dbContext = new TMDBDbContext();
        }
        public Filme Execute(Filme request)
        {
            Validate(request, _dbContext);

            var entity = new Filme
            {
                Id = request.Id,
                Title = request.Title,
                Original_language = request.Original_language,
                Original_title = request.Original_title,
                Popularity = request.Popularity,
                Release_date = request.Release_date,
                Vote_average = request.Vote_average,
                Vote_count = request.Vote_count,
                Poster_path = request.Poster_path
            };

            _dbContext.Filmes.Add(entity);

            _dbContext.SaveChanges();

            return request;
        }

        private void Validate(Filme request, TMDBDbContext dbContext)
        {
            List<string> errors = [];
            if (string.IsNullOrWhiteSpace(request.Title)) errors.Add(ExceptionMessages.TITLE_IS_EMPTY_ERROR_MESSAGE);
            if (dbContext.Filmes.Any(filme => filme.Id == request.Id)) errors.Add(ExceptionMessages.FILM_ALREADY_INCLUDED_ERROR_MESSAGE);
            if (errors.Count > 0) throw new ErrorOnValidationException(errors);
            /*var validator = new RegisterTripValidator();
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }*/
        }
    }
}
