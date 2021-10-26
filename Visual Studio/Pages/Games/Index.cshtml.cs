using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GamesData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace GamesData.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly Data.GamesDataContext _context;

        public IndexModel(Data.GamesDataContext context)
        {
            _context = context;
        }
    
        public IList<GamesTable> GamesTable { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchGames { get; set; }
   
        public SelectList GenresList { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectGenre { get; set; }
        public string GNameSort { get; set; }
        public string StudioSort { get; set; }
        public string DateSort { get; set; }

        //Search
        public async Task OnGetAsync(string sortOrder)
        {
            var searchGame = from m in _context.gamesTable
                             select m;
            IQueryable<string> searchGenres = from m in _context.gameGenre
                                              select m.GenresTable.NameGenres;
            searchGame = SortData(sortOrder);
            // поиск по названию игры 
            if (!string.IsNullOrEmpty(SearchGames)
                && string.IsNullOrEmpty(SelectGenre))
            {
                searchGame = searchGame.Where(s => s.NameGame.Contains(SearchGames));             
            }      
            // поиск по жанру
            if (!string.IsNullOrEmpty(SelectGenre) 
                && string.IsNullOrEmpty(SearchGames))
            {           
                searchGame = _context.gameGenre
                    .Where(gg => gg.GenresTable.NameGenres == SelectGenre)
                    .Select(gg => gg.GamesTable);
                searchGame = SortData(sortOrder);
            }
            if (!string.IsNullOrEmpty(SelectGenre) 
                && !string.IsNullOrEmpty(SearchGames))
            {
                searchGame = _context.gameGenre
                    .Where(gg => gg.GenresTable.NameGenres == SelectGenre)
                    .Select(gg => gg.GamesTable)
                    .Where(s => s.NameGame.Contains(SearchGames));
            }
            GenresList = new SelectList(await searchGenres.Distinct().ToListAsync());    
            GamesTable = await searchGame.ToListAsync(); 
        }

        //Sort
        public IQueryable<GamesTable> SortData(string sortOrder)
        {
            var searchGame = from m in _context.gamesTable
                             select m;
            GNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            StudioSort = sortOrder == "sname_asc" ? "sname_desc" : "sname_asc";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            switch (sortOrder)
            {
                case "name_desc":
                    searchGame = searchGame.OrderByDescending(s => s.NameGame);
                    break;
                case "sname_asc":
                    searchGame = searchGame.OrderBy(s => s.NameStudio);
                    break;
                case "sname_desc":
                    searchGame = searchGame.OrderByDescending(s => s.NameStudio);
                    break; 
                case "Date":
                    searchGame = searchGame.OrderBy(s => s.RelizeDate);
                    break;
                case "date_desc":
                    searchGame = searchGame.OrderByDescending(s => s.RelizeDate);
                    break;
                default:
                    searchGame = searchGame.OrderBy(s => s.NameGame);
                    break;
            }
            return searchGame;
        }
    }
}
