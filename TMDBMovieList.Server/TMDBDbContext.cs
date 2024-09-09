using Microsoft.EntityFrameworkCore;
using TMDBMovieList.Server.Enitites;

namespace TMDBMovieList.Server
{
    public class TMDBDbContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                string baseDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                    ?? throw new Exception("Directory path does not contain a valid database");
                #if DEBUG
                    string upperDirectory = baseDirectory.Replace("TMDBMovieList.Server\\bin\\Debug\\net8.0", "");
                #else
                    string upperDirectory = baseDirectory.Replace("TMDBMovieList.Server\\bin\\Release\\net8.0", "");
                #endif
                string dbPath = Path.Combine(upperDirectory, "TMDBDatabase.db");
                Console.WriteLine(dbPath);
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}