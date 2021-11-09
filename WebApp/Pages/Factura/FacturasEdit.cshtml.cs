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
    public class EditModel : PageModel
    {

        private readonly ServiceApi service;

        public EditModel(ServiceApi service)
        {
            this.service = service;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public FacturasEntity Entity { get; set; } = new FacturasEntity();


        public IEnumerable<ClientesEntity> ClienteLista { get; set; } = new List<ClientesEntity>();



        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await service.FacturasGetById(id.Value);
                }

                ClienteLista = await service.ClientesGetLista();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
