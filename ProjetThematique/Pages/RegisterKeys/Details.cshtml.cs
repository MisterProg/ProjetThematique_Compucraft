using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetThematique.Data;
using ProjetThematique.Models;

namespace ProjetThematique.Pages.RegisterKeys
{
    public class DetailsModel : PageModel
    {
        private readonly ProjetThematique.Data.ApplicationDbContext _context;

        public DetailsModel(ProjetThematique.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public RegisterKey RegisterKey { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RegisterKey = await _context.RegisterKey.FirstOrDefaultAsync(m => m.ID == id);

            if (RegisterKey == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
