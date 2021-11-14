
namespace App.AxiosProvider {


    export const ClientesEliminar = (id) => ServiceApi.delete<DBEntity>("api/Clientes/" + id).then(({ data }) => data);
    export const ClientesGuardar = (entity) => ServiceApi.post<DBEntity>("api/Clientes", entity).then(({ data }) => data);
    export const ClientesActualizar = (entity) => ServiceApi.put<DBEntity>("api/Clientes", entity).then(({ data }) => data);

    export const UsuarioRegistrar = (entity) => ServiceApi.post<DBEntity>("api/Usuarios/Registrar", entity).then(({ data }) => data);
    export const UsuarioLogin = (entity) => axios.post<DBEntity>("Login", entity).then(({ data }) => data);
    export const UsuarioActualizar = (entity) => ServiceApi.put<DBEntity>("api/Usuarios/Actualizar", entity).then(({ data }) => data);
    export const UsuarioEliminar = (id) => ServiceApi.delete<DBEntity>("api/Usuarios/Eliminar/" + id).then(({ data }) => data);

    export const FacturaEliminar = (id) => ServiceApi.delete<DBEntity>("api/Facturas/" + id).then(({ data }) => data);
    export const RolEliminar = (id) => ServiceApi.delete<DBEntity>("api/Roles/Eliminar/" + id).then(({ data }) => data);

    export const FacturaGuardar = (entity) => ServiceApi.post<DBEntity>("api/Facturas", entity).then(({ data }) => data);
    export const PaginasGuardar = (entity) => ServiceApi.post<DBEntity>("api/Facturas", entity).then(({ data }) => data);
    export const RolGuardar = (entity) => ServiceApi.post<DBEntity>("api/Roles/CrearRol", entity).then(({ data }) => data);
    export const RolActualizar = (entity) => ServiceApi.put<DBEntity>("api/Roles/ActualizarRol", entity).then(({ data }) => data);
    export const RolPaginaGuardar = (entity) => ServiceApi.post<DBEntity>("api/Roles/AsignarPaginaRol", entity).then(({ data }) => data);

    export const FacturaActualizar = (entity) => ServiceApi.put<DBEntity>("api/Facturas", entity).then(({ data }) => data);
    export const ObtenerPaginasId = (entity) => ServiceApi.get<DBEntity>("/api/Roles/PaginasRol/?id=" + entity.RolesId).then(({ data }) => data);


    export const RegistrarBitacoraMov = (entity) => ServiceApi.post<DBEntity>("api/BitacorasIngreso/RegistrarBitacoraMov", entity).then(({ data }) => data);

}




