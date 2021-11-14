using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;
using WebApp;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturasService facturaService;

        public FacturasController(IFacturasService facturaService)
        {
            this.facturaService = facturaService;
        }




        [HttpGet]
        public async Task<IEnumerable<FacturasEntity>> Get()
        {
            try
            {
                IEnumerable<FacturasEntity> facturasEntity =  await facturaService.Get();
                return facturasEntity;
            }
            catch (Exception ex)
            {

                return new List<FacturasEntity>();
            }
        }

        [HttpGet("{id}")]
        public async Task<FacturasEntity> GetById(int id)
        {
            try
            {
                FacturasEntity facturasEntity = await facturaService.GetById(new FacturasEntity { IdFactura = id });
                return facturasEntity;
            }
            catch (Exception ex)
            {

                return new FacturasEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }


        [HttpPost]
        public async Task<DBEntity> Create(FacturasEntity entity)
        {
            try
            {
                return await facturaService.Create(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        [HttpPut]
        public async Task<DBEntity> Update(FacturasEntity entity)
        {
            try
            {
                return await facturaService.Update(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }


        [HttpDelete("{id}")]
        public async Task<DBEntity> Delete(int id)
        {
            try
            {
                return await facturaService.Delete(new FacturasEntity() { IdFactura = id });
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }
    }
}
