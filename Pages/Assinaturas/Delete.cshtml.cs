using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudSupera.Data;
using CrudSupera.Models;

namespace CrudSupera.Pages_Assinaturas
{
    public class DeleteModel : PageModel
    {
        private readonly CrudSupera.Data.ApplicationDbContext _context;

        public DeleteModel(CrudSupera.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Assinatura Assinatura { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Assinaturas == null)
            {
                return NotFound();
            }

            var assinatura = await _context.Assinaturas.FirstOrDefaultAsync(m => m.Id == id);

            if (assinatura == null)
            {
                return NotFound();
            }
            else 
            {
                Assinatura = assinatura;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Assinaturas == null)
            {
                return NotFound();
            }
            var assinatura = await _context.Assinaturas.FindAsync(id);

            if (assinatura != null)
            {
                Assinatura = assinatura;
                _context.Assinaturas.Remove(Assinatura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
