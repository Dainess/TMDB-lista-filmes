using System.Net;

namespace TMDBMovieList.Server.Exceptions
{
    public class NotFoundException : TMDBException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public override IList<string> GetErrorMessages()
        {
            return [Message];
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.NotFound;
        }
    }
}
