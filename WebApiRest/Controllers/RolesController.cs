using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;
using Entity;


namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService rolesService;

        public RolesController(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }


        [HttpGet]
        public async Task<IEnumerable<RolesEntity>> Get()
        {
            try
            {
                return await rolesService.Get();
            }
            catch (Exception ex)
            {

                return new List<RolesEntity>();
            }
        }

        [HttpGet("{id}")]
        public async Task<RolesEntity> GetById(int id)
        {
            try
            {
                return await rolesService.GetById(new RolesEntity { RolesId = id });
            }
            catch (Exception ex)
            {

                return new RolesEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        [HttpGet("Paginas")]
        public async Task<IEnumerable<PaginasEntity>> GetPaginas()
        {
            try
            {
                return await rolesService.GetPaginas();
            }
            catch (Exception ex)
            {

                return new List<PaginasEntity>();
            }
        }


        [HttpGet("PaginasRol")]
        public async Task<IEnumerable<PaginasEntity>> GetPaginasRol(int id, int estado)
        {
            try
            {
                return await rolesService.GetPaginasRol(new RolesEntity { RolesId = id, Estado = Convert.ToBoolean(estado) });
            }
            catch (Exception ex)
            {

                return new List<PaginasEntity>();
            }
        }


        [HttpPost("CrearRol")]
        public async Task<DBEntity> CrearRol(RolesEntity entity)
        {

            try
            {
                return await rolesService.Create(entity);
            }
            catch (Exception ex)
            {

                return new UsuariosEntity() { CodeError = ex.HResult, MsgError = ex.Message };
            }

        }

        [HttpPost("AsignarPaginaRol")]
        public async Task<DBEntity> AsignarPaginaRol(PaginasAsignarEntity entity)
        {

            try
            {
                return await rolesService.AsignarPaginaRol(entity);
            }
            catch (Exception ex)
            {

                return new UsuariosEntity() { CodeError = ex.HResult, MsgError = ex.Message };
            }

        }

        [HttpPut("ActualizarRol")]
        public async Task<DBEntity> Update(RolesEntity entity)
        {
            try
            {
                return await rolesService.Update(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<DBEntity> DeleteById(int id)
        {
            try
            {
                return await rolesService.Delete(new RolesEntity { RolesId = id });
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }
    }
}
