using TMDBMovieList.Server.Enitites;
using TMDBMovieList.Server.Exceptions;

namespace TMDBMovieList.Server.Application
{
    public class DeleteFilmByIdUseCase
    {
        private readonly TMDBDbContext _dbContext;
        public DeleteFilmByIdUseCase()
        {
            _dbContext = new TMDBDbContext();
        }
        public void Execute(int id)
        {
            var filme = _dbContext
            .Filmes
            .FirstOrDefault(filme => filme.Id == id);

            if (filme is null)
                throw new NotFoundException(ExceptionMessages.FILM_NOT_FOUND_ERROR_MESSAGE);

            _dbContext.Filmes.Remove(filme);
            _dbContext.SaveChanges();
        }
    }
}
