using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;

namespace WebApp.Pages.BitacoraUsuario
{
    public class BitacorasGridModel : PageModel
    {
        private readonly ServiceApi service;

        public BitacorasGridModel(ServiceApi service)
        {
            this.service = service;
        }
        public IEnumerable<BitacorasIngresoEntity> GridList { get; set; } = new List<BitacorasIngresoEntity>();
        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await service.BitacoraIngresoGet();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }

}