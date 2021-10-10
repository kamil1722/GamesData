using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GamesData.Data
{
    public class GamesDataContext : DbContext
    {
        public GamesDataContext (DbContextOptions<GamesDataContext> options)
            : base(options)
        {
        }

        public DbSet<GamesData.Models.GamesTable> GamesTable { get; set; }

        public DbSet<GamesData.Models.GenresTable> GenresTable { get; set; }      

    }
}
