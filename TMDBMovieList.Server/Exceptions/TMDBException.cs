using System.Net;

namespace TMDBMovieList.Server.Exceptions
{
    public abstract class TMDBException : SystemException
    {
        public TMDBException(string message) : base(message) 
        { 
        }

        public abstract HttpStatusCode GetStatusCode();

        public abstract IList<string> GetErrorMessages();
    }
}
