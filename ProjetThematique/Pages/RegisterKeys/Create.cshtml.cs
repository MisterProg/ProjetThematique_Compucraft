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
    public class CreateModel : PageModel
    {
        private readonly ProjetThematique.Data.ApplicationDbContext _context;

        public CreateModel(ProjetThematique.Data.ApplicationDbContext context)
        {
            _context = context;
        }



        [BindProperty]
        public RegisterKey RegisterKey { get; set; }

        public List<SelectListItem> SelectUsersData { get; private set; }
        public IList<ApplicationUser> Users { get; set; }

        public async Task OnGetAsync()
        {
            var Roles = await _context.Roles.Where(r=>r.Name == "Admin" || r.Name == "Medecin").ToListAsync();
            var UserRoles = await _context.UserRoles.Where(r=> Roles.Any(r2 => r2.Id==r.RoleId)).ToListAsync();
            Users = await _context.Users.Where(u=> UserRoles.Any(r=> r.UserId==u.Id)).ToListAsync();

            // Initialisation de la page. Chargement de la liste déroulante des Etudiants
            SelectUsersData = new List<SelectListItem>();
            foreach (ApplicationUser u in Users)
            {
                SelectUsersData.Add(new SelectListItem
                {
                    Text = u.UserName,
                    Value = u.Id.ToString()
                });
            }

            ViewData["SelectUsersData"] = new SelectList(SelectUsersData, "Value", "Text");
        }

        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            _context.RegisterKey.Add(RegisterKey);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}