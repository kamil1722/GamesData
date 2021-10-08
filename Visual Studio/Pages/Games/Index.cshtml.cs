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

        //Добавление атрибутов для поиска
        public IList<GamesTable> GamesTable { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchGames { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GameGenre { get; set; }

        //Поиск и передача отфильтрованных значений в GamesTable
        public async Task OnGetAsync()
        {
           var searchGame = from m in _context.GamesTable
                            select m;
            if (!string.IsNullOrEmpty(SearchGames))
            {
                searchGame = searchGame.Where(s => s.NameGame.Contains(SearchGames));
            }
            GamesTable = await searchGame.ToListAsync();
        }
    }
}
