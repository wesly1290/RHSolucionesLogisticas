using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;
namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacorasIngresoController : ControllerBase
    {
        private readonly IBitacorasIngresoService bitacorasIngresoService;

        public BitacorasIngresoController(IBitacorasIngresoService bitacorasIngresoService)
        {
            this.bitacorasIngresoService = bitacorasIngresoService;
        }



        [HttpGet]
        public async Task<IEnumerable<BitacorasIngresoEntity>> Get()
        {
            try
            {
                return await bitacorasIngresoService.Get();
            }
            catch (Exception ex)
            {

                return new List<BitacorasIngresoEntity>();
            }
        }

        [HttpGet("{id}")]
        public async Task<BitacorasIngresoEntity> GetById(int id)
        {
            try
            {
                return await bitacorasIngresoService.GetById(new BitacorasIngresoEntity { UsuariosId = id });
            }
            catch (Exception ex)
            {

                return new BitacorasIngresoEntity ();
            }
        }




        [HttpPost("RegistrarBitacora")]
        public async Task<DBEntity> Create(BitacorasIngresoEntity entity)
        {
            try
            {
                return await bitacorasIngresoService.Create(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        [HttpPost("RegistrarBitacoraMov")]
        public async Task<DBEntity> CreateBitacoraMov(BitacorasMovimientoEntity entity)
        {
            try
            {
                return await bitacorasIngresoService.CreateBitacoraMov(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        [HttpGet("GetBitacoraMov")]
        public async Task<IEnumerable<BitacorasMovimientoEntity>> GetBitacoraMov()
        {
            try
            {
                return await bitacorasIngresoService.GetBitacoraMov();
            }
            catch (Exception ex)
            {

                return new List<BitacorasMovimientoEntity>();
            }
        }
    }
}
