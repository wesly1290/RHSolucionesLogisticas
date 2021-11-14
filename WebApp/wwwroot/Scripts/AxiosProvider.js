"use strict";
var App;
(function (App) {
    var AxiosProvider;
    (function (AxiosProvider) {
        AxiosProvider.ClientesEliminar = function (id) { return ServiceApi.delete("api/Clientes/" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ClientesGuardar = function (entity) { return ServiceApi.post("api/Clientes", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ClientesActualizar = function (entity) { return ServiceApi.put("api/Clientes", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.UsuarioRegistrar = function (entity) { return ServiceApi.post("api/Usuarios/Registrar", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.UsuarioLogin = function (entity) { return axios.post("Login", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.UsuarioActualizar = function (entity) { return ServiceApi.put("api/Usuarios/Actualizar", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.UsuarioEliminar = function (id) { return ServiceApi.delete("api/Usuarios/Eliminar/" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.FacturaEliminar = function (id) { return ServiceApi.delete("api/Facturas/" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.RolEliminar = function (id) { return ServiceApi.delete("api/Roles/Eliminar/" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.FacturaGuardar = function (entity) { return ServiceApi.post("api/Facturas", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.PaginasGuardar = function (entity) { return ServiceApi.post("api/Facturas", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.RolGuardar = function (entity) { return ServiceApi.post("api/Roles/CrearRol", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.RolActualizar = function (entity) { return ServiceApi.put("api/Roles/ActualizarRol", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.RolPaginaGuardar = function (entity) { return ServiceApi.post("api/Roles/AsignarPaginaRol", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.FacturaActualizar = function (entity) { return ServiceApi.put("api/Facturas", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.ObtenerPaginasId = function (entity) { return ServiceApi.get("/api/Roles/PaginasRol/?id=" + entity.RolesId).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.RegistrarBitacoraMov = function (entity) { return ServiceApi.post("api/BitacorasIngreso/RegistrarBitacoraMov", entity).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
    })(AxiosProvider = App.AxiosProvider || (App.AxiosProvider = {}));
})(App || (App = {}));
//# sourceMappingURL=AxiosProvider.js.map