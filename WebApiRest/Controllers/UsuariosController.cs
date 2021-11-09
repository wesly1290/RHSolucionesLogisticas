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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            this.usuariosService = usuariosService;
        }


        [HttpGet]
        public async Task<IEnumerable<UsuariosEntity>> Get()
        {
            try
            {
                return await usuariosService.Get();
            }
            catch (Exception ex)
            {

                return new List<UsuariosEntity>();
            }
        }

        [HttpGet("{id}")]
        public async Task<UsuariosEntity> GetById(int id)
        {
            try
            {
                return await usuariosService.GetById(new UsuariosEntity { UsuariosId = id });
            }
            catch (Exception ex)
            {

                return new UsuariosEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        [HttpPost("Login")]
        public async Task<UsuariosEntity> Login(UsuariosEntity entity)
        {

            try
            {
                return await usuariosService.Login(entity);
            }
            catch (Exception ex)
            {

                return new UsuariosEntity() { CodeError=ex.HResult, MsgError=ex.Message };
            }
        
        }


        [HttpPost("Registrar")]
        public async Task<DBEntity> Registrar(UsuariosEntity entity)
        {

            try
            {
                return await usuariosService.Registrar(entity);
            }
            catch (Exception ex)
            {

                return new UsuariosEntity() { CodeError = ex.HResult, MsgError = ex.Message };
            }

        }
    }
}
