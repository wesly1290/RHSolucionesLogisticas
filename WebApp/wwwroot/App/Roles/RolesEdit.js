"use strict";
var RolesEdit;
(function (RolesEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Rights = $("#Rights").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
        },
        methods: {
            RegistraServicio: function (entity) {
                if (entity.RolesId == null) {
                    return App.AxiosProvider.RolGuardar(entity);
                }
                else {
                    return App.AxiosProvider.RolActualizar(entity);
                }
            },
            Save: function () {
                var _this = this;
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Saving...");
                    this.RegistraServicio(this.Entity).then(function (data) {
                        var mensaje = "";
                        if (data.CodeError == 0) {
                            var roleid = 0;
                            if (_this.Entity.RolesId == null) {
                                roleid = data.RegisterId;
                            }
                            else
                                roleid = _this.Entity.RolesId;
                            var checked, permiso;
                            $('#Rights input[type=checkbox]').each(function () {
                                if ($(this).prop('checked')) {
                                    checked = true;
                                }
                                else {
                                    checked = false;
                                }
                                permiso = $(this).val();
                                RegistraPermisoPagina(roleid, checked, parseInt(permiso)).then(function (data) {
                                    if (data.CodeError == 0) {
                                    }
                                    else {
                                        mensaje += data.MsgError + "<br>";
                                    }
                                }).catch(function (c) { return console.log(c); });
                            });
                            if (mensaje == "") {
                                var movimiento = "";
                                if (Entity.RolesId != null) {
                                    movimiento = "The role " + Entity.RolesId + " has been updated";
                                }
                                else {
                                    movimiento = "A new role has been created";
                                }
                                var tableInstance = {
                                    UsuariosId: parseInt(SessionID),
                                    DescripcionMovimiento: movimiento
                                };
                                App.AxiosProvider.RegistrarBitacoraMov(tableInstance);
                                Toast.fire({ title: "Successfully saved!", icon: "success" })
                                    .then(function () { return window.location.href = "Roles/RolesGrid"; });
                            }
                            else
                                Toast.fire({ title: "Errors occurred while saving " + mensaje, icon: "error" });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    }).catch(function (c) { return console.log(c); });
                    Loading.close();
                }
                else {
                    Toast.fire({ title: "Please complete the required fields!", icon: "error" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    function CheckAll() {
        $('#Rights input[type=checkbox]').each(function () {
            if ($('#AllRight').prop('checked')) {
                $(this).prop('checked', true);
            }
            else {
                $(this).prop('checked', false);
            }
        });
    }
    RolesEdit.CheckAll = CheckAll;
    function RegistraPermisoPagina(roleid, checked, permiso) {
        var tableInstance = {
            RolesId: roleid,
            PaginasId: permiso,
            Check: checked,
        };
        return App.AxiosProvider.RolPaginaGuardar(tableInstance);
    }
    RolesEdit.RegistraPermisoPagina = RegistraPermisoPagina;
    Formulario.$mount("#AppEdit");
    window.onload = function () {
        console.log("ONLOAD");
        var Entity = $("#AppEdit").data("entity");
        var Rights = $("#Rights").data("entity");
        if (Rights.length > 0) {
            CheckRight(Rights);
        }
    };
    function CheckRight(Rights) {
        $('#Rights input[type=checkbox]').each(function () {
            for (var i = 0; i < Rights.length; i++) {
                if ($(this).val() == Rights[i].PaginasId) {
                    $(this).prop('checked', true);
                }
            }
        });
    }
    RolesEdit.CheckRight = CheckRight;
})(RolesEdit || (RolesEdit = {}));
//# sourceMappingURL=RolesEdit.js.map