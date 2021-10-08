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

namespace GamesData.Pages.Genres
{
    public class EditModel : PageModel
    {
        private readonly GamesData.Data.GamesDataContext _context;

        public EditModel(GamesData.Data.GamesDataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GenresTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenresTableExists(GenresTable.ID))
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

        private bool GenresTableExists(int id)
        {
            return _context.GenresTable.Any(e => e.ID == id);
        }
    }
}
