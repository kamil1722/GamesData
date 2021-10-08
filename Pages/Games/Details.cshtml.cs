﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly GamesData.Data.GamesDataContext _context;

        public DetailsModel(GamesData.Data.GamesDataContext context)
        {
            _context = context;
        }

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
    }
}