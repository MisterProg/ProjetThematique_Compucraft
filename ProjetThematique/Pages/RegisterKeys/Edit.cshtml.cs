using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetThematique.Data;
using ProjetThematique.Models;

namespace ProjetThematique.Pages.RegisterKeys
{
    public class EditModel : PageModel
    {
        private readonly ProjetThematique.Data.ApplicationDbContext _context;

        public EditModel(ProjetThematique.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RegisterKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterKeyExists(RegisterKey.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RegisterKeyExists(int id)
        {
            return _context.RegisterKey.Any(e => e.ID == id);
        }
    }
}
