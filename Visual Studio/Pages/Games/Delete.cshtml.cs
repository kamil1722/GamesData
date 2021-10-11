using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GamesData.Data;
using GamesData.Models;

namespace GamesData.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly GamesData.Data.GamesDataContext _context;

        public DeleteModel(GamesData.Data.GamesDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GamesTable GamesTable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GamesTable = await _context.gamesTable.FirstOrDefaultAsync(m => m.ID == id);

            if (GamesTable == null)
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

            GamesTable = await _context.gamesTable.FindAsync(id);

            if (GamesTable != null)
            {
                _context.gamesTable.Remove(GamesTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
