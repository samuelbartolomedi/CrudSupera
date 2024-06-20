using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudSupera.Data;
using CrudSupera.Models;

namespace CrudSupera.Pages_Assinaturas
{
    public class EditModel : PageModel
    {
        private readonly CrudSupera.Data.ApplicationDbContext _context;

        public EditModel(CrudSupera.Data.ApplicationDbContext context)
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

            var assinatura =  await _context.Assinaturas.FirstOrDefaultAsync(m => m.Id == id);
            if (assinatura == null)
            {
                return NotFound();
            }
            Assinatura = assinatura;
           ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Cpf");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Assinatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssinaturaExists(Assinatura.Id))
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

        private bool AssinaturaExists(int id)
        {
          return (_context.Assinaturas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
