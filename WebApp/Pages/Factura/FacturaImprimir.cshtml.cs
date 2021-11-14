using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Factura
{
    public class FacturaImprimirModel : PageModel
    {
        private readonly ServiceApi service;

        public FacturaImprimirModel(ServiceApi service)
        {
            this.service = service;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public FacturasEntity Entity { get; set; } = new FacturasEntity();


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await service.FacturasGetById(id.Value);
                }

                HttpContext.Session.Set("FacturaGet", Entity);

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
