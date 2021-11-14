"use strict";
var UsuariosEdit;
(function (UsuariosEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
        },
        methods: {
            RegistraServicio: function (entity) {
                if (entity.UsuariosId == null) {
                    return App.AxiosProvider.UsuarioRegistrar(entity);
                }
                else {
                    return App.AxiosProvider.UsuarioActualizar(entity);
                }
            },
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Saving...");
                    this.RegistraServicio(this.Entity).then(function (data) {
                        var mensaje = "";
                        if (data.CodeError == 0) {
                            var movimiento = "";
                            if (Entity.UsuariosId != null) {
                                movimiento = "The user " + Entity.UsuariosId + " has been updated";
                            }
                            else {
                                movimiento = "A new user has been created";
                            }
                            var tableInstance = {
                                UsuariosId: parseInt(SessionID),
                                DescripcionMovimiento: movimiento
                            };
                            App.AxiosProvider.RegistrarBitacoraMov(tableInstance);
                            Toast.fire({ title: "Successfully saved!", icon: "success" })
                                .then(function () { return window.location.href = "Usuario/UsuariosGrid"; });
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
    Formulario.$mount("#AppEdit");
})(UsuariosEdit || (UsuariosEdit = {}));
//# sourceMappingURL=UsuariosEdit.js.map