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

        //Добавление таблиц для поиска
        public IList<GamesTable> GamesTable { get; set; }
        //Добавление строки поиска
        [BindProperty(SupportsGet = true)]
        public string SearchGames { get; set; }

        //Добавление строки выбора жанра из списка жанров
        public SelectList GenresList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectGenre { get; set; }

        //Поиск и передача отфильтрованных значений в GamesTable и GenresList
        public async Task OnGetAsync()
        {
            var searchGame = from m in _context.gamesTable
                             select m;
            
            if (!string.IsNullOrEmpty(SearchGames))
            {
                searchGame = searchGame.Where(s => s.NameGame.Contains(SearchGames));
            }
            // поиск по жанру
            IQueryable<string> searchGenres = from m in _context.gameGenre
                                                              select m.GenresTable.NameGenres;
            if (!string.IsNullOrEmpty(SelectGenre))
            {
                searchGame = _context.gameGenre.Where(gg => gg.GenresTable.NameGenres == SelectGenre).Select(gg => gg.GamesTable);       
            }
            GamesTable = await searchGame.ToListAsync();
            GenresList = new SelectList(await searchGenres.Distinct().ToListAsync());        
        }
    }
}
