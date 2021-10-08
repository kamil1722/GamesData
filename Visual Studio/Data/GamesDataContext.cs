using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GamesData.Models;
using GamesData;

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
        public DbSet<GamesData.Models.JoinTables> JoinTables { get; set; }

    }
}
