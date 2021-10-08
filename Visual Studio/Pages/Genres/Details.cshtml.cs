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
    public class DetailsModel : PageModel
    {
        private readonly GamesData.Data.GamesDataContext _context;

        public DetailsModel(GamesData.Data.GamesDataContext context)
        {
            _context = context;
        }

        public GenresTable GenresTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GenresTable = await _context.GenresTable.FirstOrDefaultAsync(m => m.ID == id);

            if (GenresTable == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
