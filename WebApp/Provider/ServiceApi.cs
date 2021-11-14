using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp
{
    public class ServiceApi
    {
        private readonly HttpClient client;

        public ServiceApi(HttpClient client)
        {
            this.client = client;
        }

        #region Clientes

        public async Task<IEnumerable<ClientesEntity>> ClientesGet()
        {
            var result = await client.ServicioGetAsync<IEnumerable<ClientesEntity>>("api/Clientes");

            return result;


        }

        public async Task<IEnumerable<ClientesEntity>> ClientesGetLista()
        {
            var result = await client.ServicioGetAsync<IEnumerable<ClientesEntity>>("api/Clientes/Lista");

            return result;

        }

        public async Task<ClientesEntity> ClientesGetById(int id)
        {
            var result = await client.ServicioGetAsync<ClientesEntity>("api/Clientes/" + id);

            if (result.CodeError is not 0) throw new Exception(result.MsgError);

            return result;


        }


        #endregion

        #region Usuario

        public async Task<IEnumerable<UsuariosEntity>> UsuariosGet()
        {
            var result = await client.ServicioGetAsync<IEnumerable<UsuariosEntity>>("api/Usuarios");

            return result;



        }
        public async Task<UsuariosEntity> UsuariosGetById(int id)
        {
            var result = await client.ServicioGetAsync<UsuariosEntity>("api/Usuarios/" + id);

            if (result.CodeError is not 0) throw new Exception(result.MsgError);

            return result;


        }
        public async Task<UsuariosEntity> UsuarioLogin(UsuariosEntity entity)
        {

            var result = await client.ServicioPostAsync<UsuariosEntity>("api/Usuarios/Login", entity);

            return result;
        }


        #endregion


        #region Facturas
        public async Task<IEnumerable<FacturasEntity>> FacturasGet()
        {
            var result = await client.ServicioGetAsync<IEnumerable<FacturasEntity>>("api/Facturas");

            return result;

        }

        public async Task<FacturasEntity> FacturasGetById(int id)
        {
            var result = await client.ServicioGetAsync<FacturasEntity>("api/Facturas/" + id);

            if (result.CodeError is not 0) throw new Exception(result.MsgError);

            return result;

        }

        #endregion

        #region Roles
        public async Task<IEnumerable<RolesEntity>> RolesGetLista()
        {
            var result = await client.ServicioGetAsync<IEnumerable<RolesEntity>>("api/Roles/");

            return result;

        }
        public async Task<RolesEntity> RolesGetById(int id)
        {
            var result = await client.ServicioGetAsync<RolesEntity>("api/Roles/" + id);

            if (result.CodeError is not 0) throw new Exception(result.MsgError);

            return result;

        }

        public async Task<IEnumerable<PaginasEntity>> GetPaginas()
        {
            var result = await client.ServicioGetAsync<IEnumerable<PaginasEntity>>("api/Roles/Paginas");

            return result;

        }

        public async Task<IEnumerable<PaginasEntity>> GetPaginasRol(int id, int estado)
        {
            var result = await client.ServicioGetAsync<IEnumerable<PaginasEntity>>("/api/Roles/PaginasRol/?id=" + id + "&Estado=" + estado);

            return result;

        }

        #endregion


        #region Bitacora
        public async Task<IEnumerable<BitacorasIngresoEntity>> BitacoraIngresoGet()
        {
            var result = await client.ServicioGetAsync<IEnumerable<BitacorasIngresoEntity>>("api/BitacorasIngreso/");

            return result;

        }

        public async Task<IEnumerable<BitacorasMovimientoEntity>> GetBitacoraMov()
        {
            var result = await client.ServicioGetAsync<IEnumerable<BitacorasMovimientoEntity>>("api/BitacorasIngreso/GetBitacoraMov/");

            return result;

        }

        public async Task<BitacorasIngresoEntity> RegistraBitacoraLogin(BitacorasIngresoEntity entity)
        {

            var result = await client.ServicioPostAsync<BitacorasIngresoEntity>("api/BitacorasIngreso/RegistrarBitacora", entity);

            return result;
        }

        #endregion
    }
}
