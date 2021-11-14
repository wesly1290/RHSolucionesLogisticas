using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IRolesService
    {
        Task<DBEntity> Create(RolesEntity entity);
        Task<DBEntity> Delete(RolesEntity entity);
        Task<IEnumerable<RolesEntity>> Get();
        Task<RolesEntity> GetById(RolesEntity entity);
        Task<IEnumerable<PaginasEntity>> GetPaginas();
        Task<IEnumerable<PaginasEntity>> GetPaginasRol(RolesEntity entity);
        Task<DBEntity> AsignarPaginaRol(PaginasAsignarEntity entity);
        Task<DBEntity> Update(RolesEntity entity);
    }
    public class RolesService : IRolesService
    {

        private readonly IDataAccess sql;

        public RolesService(IDataAccess _sql)
        {
            sql = _sql;
        }


        public async Task<IEnumerable<RolesEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<RolesEntity>("RolesLista");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PaginasEntity>> GetPaginas()
        {
            try
            {
                var result = sql.QueryAsync<PaginasEntity>("PaginasObtener");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PaginasEntity>> GetPaginasRol(RolesEntity entity)
        {
            try
            {
                var result = sql.QueryAsync<PaginasEntity>("PaginasObtenerRol", new
                {
                    entity.RolesId,
                    entity.Estado
                });

                return await result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RolesEntity> GetById(RolesEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<RolesEntity>("RolesLista", new
                {
                    entity.RolesId
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<DBEntity> Create(RolesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("RolesInsertar", new
                {
                    entity.NombreRol,
                    entity.Descripcion,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> AsignarPaginaRol(PaginasAsignarEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("PaginasPermisoRegistrar", new
                {
                    entity.RolesId,
                    entity.PaginasId,
                    entity.Check
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(RolesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("RolesActualizar", new
                {
                    entity.RolesId,
                    entity.NombreRol,
                    entity.Descripcion,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(RolesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("RolesEliminar", new
                {
                    entity.RolesId,
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
