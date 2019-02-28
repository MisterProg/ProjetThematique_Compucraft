using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetThematique.Data;
using ProjetThematique.Models;

namespace ProjetThematique.Pages.RegisterKeys
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ProjetThematique.Data.ApplicationDbContext _context;

        public IndexModel(ProjetThematique.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<RegisterKey> RegisterKey { get;set; }

        public async Task OnGetAsync()
        {
            RegisterKey = await _context.RegisterKey.ToListAsync();
        }
    }
}
