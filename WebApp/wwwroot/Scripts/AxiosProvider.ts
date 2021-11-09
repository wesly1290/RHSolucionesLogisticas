
namespace App.AxiosProvider   {

    
    export const ClientesEliminar = (id) => ServiceApi.delete<DBEntity>("api/Clientes/" + id).then(({ data }) => data);
    export const ClientesGuardar = (entity) => ServiceApi.post<DBEntity>("api/Clientes", entity).then(({ data }) => data);
    export const ClientesActualizar = (entity) => ServiceApi.put<DBEntity>("api/Clientes", entity).then(({ data }) => data);

    export const UsuarioRegistrar = (entity) => ServiceApi.post<DBEntity>("api/Usuarios/Registrar", entity).then(({ data }) => data);
    export const UsuarioLogin = (entity) => axios.post<DBEntity>("Login", entity).then(({ data }) => data);

    export const FacturaEliminar = (id) => ServiceApi.delete<DBEntity>("api/Facturas/" + id).then(({ data }) => data);

    export const FacturaGuardar = (entity) => ServiceApi.post<DBEntity>("api/Facturas", entity).then(({ data }) => data);

    export const FacturaActualizar = (entity) => ServiceApi.put<DBEntity>("api/Facturas", entity).then(({ data }) => data);
}




