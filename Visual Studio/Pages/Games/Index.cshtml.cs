using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GamesData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using GamesData.Controllers;

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
        public IList<GenresTable> GenresTable { get; set; }
        
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
            var searchGame = from m in _context.GamesTable
                            select m;
            if (!string.IsNullOrEmpty(SearchGames))
            {
                searchGame = searchGame.Where(s => s.NameGame.Contains(SearchGames));
            }
            // потуги с поиском по жанру
            IQueryable<string> searchGenres = from m in _context.GenresTable
                                               select m.NameGenres;
            if (!string.IsNullOrEmpty(SelectGenre))
            {
                searchGame = searchGame.Where(x => x.NameGame == SelectGenre);
            }
            GamesTable = await searchGame.ToListAsync();
            GenresList = new SelectList(await searchGenres.Distinct().ToListAsync());
        }
    }
}
