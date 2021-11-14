using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IBitacorasIngresoService
    {
        Task<DBEntity> Create(BitacorasIngresoEntity entity);
        Task<IEnumerable<BitacorasIngresoEntity>> Get();
        Task<BitacorasIngresoEntity> GetById(BitacorasIngresoEntity entity); 
        Task<DBEntity> CreateBitacoraMov(BitacorasMovimientoEntity entity);
        Task<IEnumerable<BitacorasMovimientoEntity>> GetBitacoraMov();
    }

    public class BitacorasIngresoService : IBitacorasIngresoService
    {
        private readonly IDataAccess sql;

        public BitacorasIngresoService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<BitacorasIngresoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<BitacorasIngresoEntity>("BitacoraObtener");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BitacorasIngresoEntity> GetById(BitacorasIngresoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<BitacorasIngresoEntity>("BitacoraObtener", new
                {
                    entity.UsuariosId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<DBEntity> Create(BitacorasIngresoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("BitacoraLogInsertar", new
                {
                    entity.UsuariosId,
                    entity.IngresoSalida
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<DBEntity> CreateBitacoraMov(BitacorasMovimientoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("BitacoraMovInsertar", new
                {
                    entity.UsuariosId,
                    entity.DescripcionMovimiento
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<IEnumerable<BitacorasMovimientoEntity>> GetBitacoraMov()
        {
            try
            {
                var result = sql.QueryAsync<BitacorasMovimientoEntity>("BitacoraMovObtener");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
