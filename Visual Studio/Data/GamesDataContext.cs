using Microsoft.EntityFrameworkCore;

namespace GamesData.Data
{
    public class GamesDataContext : DbContext
    {
        public GamesDataContext(DbContextOptions<GamesDataContext> options)
            : base(options)
        {
        }

        public DbSet<GamesData.Models.GamesTable> gamesTable { get; set; }

        public DbSet<GamesData.Models.GenresTable> genresTable { get; set; }
        public DbSet<GamesData.Models.GameGenre> gameGenre { get; set; }

    }
}
