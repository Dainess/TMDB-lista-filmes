namespace TMDBMovieList.Server.Enitites
{
    public class Pao
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Flavor { get; set; }

        public decimal Price { get; set; }
    }
}
