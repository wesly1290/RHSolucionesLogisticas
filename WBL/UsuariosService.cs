using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IUsuariosService
    {
        Task<DBEntity> Create(UsuariosEntity entity);
        Task<DBEntity> Delete(UsuariosEntity entity);
        Task<IEnumerable<UsuariosEntity>> Get();
        Task<UsuariosEntity> GetById(UsuariosEntity entity);
        Task<UsuariosEntity> Login(UsuariosEntity entity);
        Task<DBEntity> Registrar(UsuariosEntity entity);
        Task<DBEntity> Update(UsuariosEntity entity);
    }

    public class UsuariosService : IUsuariosService
    {

        private readonly IDataAccess sql;

        public UsuariosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<UsuariosEntity> Login(UsuariosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<UsuariosEntity>("Login", new
                {

                    entity.Usuario,
                    entity.Contrasena,

                });

                return await result;

            }
            catch (Exception)
            {

                throw;
            }



        }

        public async Task<DBEntity> Registrar(UsuariosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("UsuarioRegistrar", new
                {
                    entity.Usuario,
                    entity.Nombre,
                    entity.RolesId,
                    entity.Contrasena
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<IEnumerable<UsuariosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<UsuariosEntity>("UsuariosObtener");

                return await result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UsuariosEntity> GetById(UsuariosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<UsuariosEntity>("UsuariosObtener", new
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



        public async Task<DBEntity> Create(UsuariosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("UsuariosRegistrar", new
                {
                    entity.Usuario,
                    entity.Nombre,
                    entity.Rol,
                    entity.Contrasena,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(UsuariosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("UsuariosActualizar", new
                {
                    entity.UsuariosId,
                    entity.Usuario,
                    entity.Nombre,
                    entity.Rol,
                    entity.Contrasena,
                    entity.Estado,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(UsuariosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("UsuariosEliminar", new
                {
                    entity.UsuariosId,
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
