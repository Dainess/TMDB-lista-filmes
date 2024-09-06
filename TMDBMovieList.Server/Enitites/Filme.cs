namespace TMDBMovieList.Server.Enitites
{
    public class Filme
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Original_language { get; set; } = string.Empty;
        public string Original_title { get; set; } = string.Empty;
        public int Popularity { get; set; }
        public DateTime? Release_date { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }
        public string? Poster_path { get; set; } = string.Empty;
    }
}
