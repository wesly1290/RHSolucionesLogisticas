using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IFacturasService
    {
        Task<DBEntity> Create(FacturasEntity entity);
        Task<DBEntity> Delete(FacturasEntity entity);
        Task<IEnumerable<FacturasEntity>> Get();
        Task<FacturasEntity> GetById(FacturasEntity entity);
        Task<DBEntity> Update(FacturasEntity entity);
    }

    public class FacturaService : IFacturasService
    {
        private readonly IDataAccess sql;

        public FacturaService(IDataAccess _sql)
        {
            sql = _sql;
        }


        public async Task<IEnumerable<FacturasEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<FacturasEntity, ClientesEntity>(sp: "FacturasObtener", split: "ClientesId");

                return await result;
            }
            catch (Exception EX)
            {

                throw;
            }
        }



        public async Task<FacturasEntity> GetById(FacturasEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<FacturasEntity>("FacturasObtener", new
                {
                    entity.IdFactura
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<DBEntity> Create(FacturasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("FacturasInsertar", new
                {
                    entity.ClientesId,
                    entity.Pedido,
                    entity.TipoServicio,
                    entity.FechaPedido,
                    entity.Monto,
                    entity.Impuesto,
                    Total = (entity.Monto * (entity.Impuesto / 100)) + entity.Monto,
                    entity.Observaciones,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Update(FacturasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("FacturasActualizar", new
                {
                    entity.IdFactura,
                    entity.ClientesId,
                    entity.Pedido,
                    entity.TipoServicio,
                    entity.FechaPedido,
                    entity.Monto,
                    entity.Impuesto,
                    Total = (entity.Monto * (entity.Impuesto / 100)) + entity.Monto,
                    entity.Observaciones,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<DBEntity> Delete(FacturasEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("FacturasEliminar", new
                {
                    entity.IdFactura,
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
