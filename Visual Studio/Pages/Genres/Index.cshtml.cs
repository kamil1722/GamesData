using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GamesData.Data;
using GamesData.Models;

namespace GamesData.Pages.Genres
{
    public class IndexModel : PageModel
    {
        private readonly GamesData.Data.GamesDataContext _context;

        public IndexModel(GamesData.Data.GamesDataContext context)
        {
            _context = context;
        }

        public IList<GenresTable> GenresTable { get;set; }

        public async Task OnGetAsync()
        {
            GenresTable = await _context.GenresTable.ToListAsync();
        }
    }
}
