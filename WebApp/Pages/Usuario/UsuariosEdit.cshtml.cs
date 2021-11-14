using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Usuario
{
    public class UsuariosEditModel : PageModel
    {

        private readonly ServiceApi service;
        
        public UsuariosEditModel(ServiceApi service)
        {
            this.service = service;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public IEnumerable<RolesEntity> RolesEntity { get; set; } = new List<RolesEntity>();

        public UsuariosEntity Entity { get; set; } = new UsuariosEntity();



        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await service.UsuariosGetById(id.Value);
                }

                RolesEntity = await service.RolesGetLista();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
