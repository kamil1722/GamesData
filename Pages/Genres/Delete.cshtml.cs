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
    public class DeleteModel : PageModel
    {
        private readonly GamesData.Data.GamesDataContext _context;

        public DeleteModel(GamesData.Data.GamesDataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GenresTable = await _context.GenresTable.FindAsync(id);

            if (GenresTable != null)
            {
                _context.GenresTable.Remove(GenresTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
