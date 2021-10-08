using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamesData.Data;
using GamesData.Models;

namespace GamesData.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly GamesData.Data.GamesDataContext _context;

        public EditModel(GamesData.Data.GamesDataContext context)
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

            GamesTable = await _context.GamesTable.FirstOrDefaultAsync(m => m.ID == id);

            if (GamesTable == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GamesTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesTableExists(GamesTable.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GamesTableExists(int id)
        {
            return _context.GamesTable.Any(e => e.ID == id);
        }
    }
}
