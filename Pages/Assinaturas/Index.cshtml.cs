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
    public class IndexModel : PageModel
    {
        private readonly CrudSupera.Data.ApplicationDbContext _context;

        public IndexModel(CrudSupera.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Assinatura> Assinatura { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Assinaturas != null)
            {
                Assinatura = await _context.Assinaturas
                .Include(a => a.Cliente).ToListAsync();
            }
        }
    }
}
