using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GamesData.Models;
using System.ComponentModel.DataAnnotations;


namespace GamesData.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly GamesData.Data.GamesDataContext _context;
        public DetailsModel(GamesData.Data.GamesDataContext context)
        {
            _context = context;
        }
        public GamesTable game { get; set; }
        [Display(Name = "Genre")]
        public GenresTable genres { get; set; }
        //public SelectList genresList { get; set; }
        public string str { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }     
            var guery =  await _context.gameGenre.Join(_context.genresTable,
                t1 => t1.GenresTableID,
                t2 => t2.ID,
                (t1, t2) => new
                {
                    GenresID = t2.ID,
                    GamesTableID = t1.GamesTableID,
                    NameGenre = t2.NameGenres
                }).Where(m => m.GamesTableID == id).ToListAsync();
           
            str = string.Join(", ", guery.Select(m => m.NameGenre));
            game = await _context.gamesTable.FirstOrDefaultAsync(m => m.ID == id);
            //genresList = new SelectList(guery, "GenresID", "NameGenre");
            if (game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
