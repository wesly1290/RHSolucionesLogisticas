using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Roles
{
    public class RolesEditModel : PageModel
    {
        private readonly ServiceApi service;

        public RolesEditModel(ServiceApi service)
        {
            this.service = service;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public RolesEntity Entity { get; set; } = new RolesEntity();


        public IEnumerable<PaginasEntity> PaginasLista { get; set; } = new List<PaginasEntity>();
        public IEnumerable<PaginasEntity> PaginasRol { get; set; } = new List<PaginasEntity>();



        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await service.RolesGetById(id.Value);
                    PaginasRol = await service.GetPaginasRol(id.Value, 0);
                }

                PaginasLista = await service.GetPaginas();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
