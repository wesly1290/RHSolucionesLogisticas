using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;

namespace WebApp.Pages.Usuario
{
    public class UsuariosGridModel : PageModel
    {
        private readonly ServiceApi service;

        public UsuariosGridModel(ServiceApi service)
        {
            this.service = service;
        }
        public IEnumerable<UsuariosEntity> GridList { get; set; } = new List<UsuariosEntity>();
        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await service.UsuariosGet();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
