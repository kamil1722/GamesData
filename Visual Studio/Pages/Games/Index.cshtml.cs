using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GamesData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace GamesData.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly GamesData.Data.GamesDataContext _context;

        public IndexModel(GamesData.Data.GamesDataContext context)
        {
            _context = context;
        }
    
        public IList<GamesTable> GamesTable { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchGames { get; set; }
   
        public SelectList GenresList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectGenre { get; set; }
   
        public async Task OnGetAsync()
        {
            var searchGame = from m in _context.gamesTable
                             select m;
            IQueryable<string> searchGenres = from m in _context.gameGenre
                                              select m.GenresTable.NameGenres;
            // поиск по названию игры 
            if (!string.IsNullOrEmpty(SearchGames) && string.IsNullOrEmpty(SelectGenre))
            {
                searchGame = searchGame.Where(s => s.NameGame.Contains(SearchGames));
            }
         
            // поиск по жанру
            if (!string.IsNullOrEmpty(SelectGenre) && string.IsNullOrEmpty(SearchGames))
            {
                searchGame = _context.gameGenre
                    .Where(gg => gg.GenresTable.NameGenres == SelectGenre)
                    .Select(gg => gg.GamesTable);       
            }

            if (!string.IsNullOrEmpty(SelectGenre) && !string.IsNullOrEmpty(SearchGames))
            {
                searchGame = _context.gameGenre
                    .Where(gg => gg.GenresTable.NameGenres == SelectGenre)
                    .Select(gg => gg.GamesTable)
                    .Where(s => s.NameGame.Contains(SearchGames));
            }
   
            GenresList = new SelectList(await searchGenres.Distinct().ToListAsync());
            GamesTable = await searchGame.ToListAsync();
                
        }
    }
}
