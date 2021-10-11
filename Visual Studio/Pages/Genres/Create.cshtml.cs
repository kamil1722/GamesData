using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GamesData.Data;
using GamesData.Models;

namespace GamesData.Pages.Genres
{
    public class CreateModel : PageModel
    {
        private readonly GamesData.Data.GamesDataContext _context;

        public CreateModel(GamesData.Data.GamesDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GenresTable GenresTable { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.genresTable.Add(GenresTable);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
