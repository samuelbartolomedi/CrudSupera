using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrudSupera.Data;
using CrudSupera.Models;

namespace CrudSupera.Pages_Assinaturas
{
    public class CreateModel : PageModel
    {
        private readonly CrudSupera.Data.ApplicationDbContext _context;

        public CreateModel(CrudSupera.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Cpf");
            return Page();
        }

        [BindProperty]
        public Assinatura Assinatura { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Assinaturas == null || Assinatura == null)
            {
                return Page();
            }

            _context.Assinaturas.Add(Assinatura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
