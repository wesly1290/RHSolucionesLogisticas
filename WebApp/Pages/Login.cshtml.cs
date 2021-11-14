using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ServiceApi serviceApi;

        public LoginModel(ServiceApi serviceApi)
        {
            this.serviceApi = serviceApi;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [FromBody]
        [BindProperty]

        public UsuariosEntity Entity { get; set; } = new UsuariosEntity();


        public async Task<IActionResult> OnPost()
        {

            try
            {
                var result = await serviceApi.UsuarioLogin(Entity);
                if (result.CodeError == 0)
                {

                    var UsuarioSession = HttpContext.Session.Get<UsuariosEntity>(IApp.UsuarioSession);

                    BitacorasIngresoEntity bitacorasIngresoEntity = new BitacorasIngresoEntity();

                    bitacorasIngresoEntity.IngresoSalida = "Log in";
                    bitacorasIngresoEntity.UsuariosId = result.UsuariosId;

                    var resultBit = await serviceApi.RegistraBitacoraLogin(bitacorasIngresoEntity);

                    PaginasRolEntity pagRol = new PaginasRolEntity();
                    HttpContext.Session.Set<UsuariosEntity>(IApp.UsuarioSession, result);


                    if (result.RolesId != null)
                    {
                        List<PaginasEntity> paginas = (List<PaginasEntity>)await serviceApi.GetPaginasRol((int)result.RolesId, 1);

                        foreach (var item in paginas)
                        {
                            switch (item.NombrePagina)
                            {
                                case "Customer":
                                    pagRol.Customer = true;
                                    break;
                                case "Users":
                                    pagRol.Users = true;
                                    break;
                                case "Invoice":
                                    pagRol.Invoice = true;
                                    break;
                                case "RoleMaintenance":
                                    pagRol.RoleMaintenance = true;
                                    break;
                                case "Reports":
                                    pagRol.Reports = true;
                                    break;
                                case "UserLog":
                                    pagRol.UserLog = true;
                                    break;
                                case "MovementLog":
                                    pagRol.MovementLog = true;
                                    break;
                            }
                        }
                    }

                    HttpContext.Session.Set<PaginasRolEntity>("PaginasRol", pagRol);

                    return new JsonResult(result);
                }
                else
                {
                    return new JsonResult(result);
                }

            }

            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }
        public async Task<IActionResult> OnGetLogoutAsync()
        {
            try
            {
                var UsuarioSession = HttpContext.Session.Get<UsuariosEntity>(IApp.UsuarioSession);


                BitacorasIngresoEntity bitacorasIngresoEntity = new BitacorasIngresoEntity();

                bitacorasIngresoEntity.IngresoSalida = "Log out";
                bitacorasIngresoEntity.UsuariosId = UsuarioSession.UsuariosId;

                var resultBit = await serviceApi.RegistraBitacoraLogin(bitacorasIngresoEntity);



            }
            catch (Exception)
            {

            }
            HttpContext.Session.Clear();

            return Redirect("../Login");
        }
    }
}
