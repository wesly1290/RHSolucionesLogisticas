using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;


namespace WebApp.Pages.MovimientoBitacora
{
    public class MovimientoBitacoraGridModel : PageModel
    {
        private readonly ServiceApi service;

        public MovimientoBitacoraGridModel(ServiceApi service)
        {
            this.service = service;
        }
        public IEnumerable<BitacorasMovimientoEntity> GridList { get; set; } = new List<BitacorasMovimientoEntity>();
        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await service.GetBitacoraMov();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }

}
