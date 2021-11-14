using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;

namespace WebApp.Pages.Roles
{
    public class RolesGridModel : PageModel
    {
        private readonly ServiceApi service;

        public RolesGridModel(ServiceApi service)
        {
            this.service = service;
        }
        public IEnumerable<RolesEntity> GridList { get; set; } = new List<RolesEntity>();
        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await service.RolesGetLista();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
