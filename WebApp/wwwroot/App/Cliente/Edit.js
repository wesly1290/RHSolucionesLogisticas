"use strict";
var ClienteEdit;
(function (ClienteEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
        },
        methods: {
            ClienteServicio: function (entity) {
                console.log(entity);
                if (entity.ClientesId == null) {
                    return App.AxiosProvider.ClientesGuardar(entity);
                }
                else {
                    return App.AxiosProvider.ClientesActualizar(entity);
                }
            },
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Saving...");
                    this.ClienteServicio(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            var movimiento = "";
                            if (Entity.ClientesId != null) {
                                movimiento = "The customer " + Entity.ClientesId + " has been updated";
                            }
                            else {
                                movimiento = "A new customer has been created";
                            }
                            var tableInstance = {
                                UsuariosId: parseInt(SessionID),
                                DescripcionMovimiento: movimiento
                            };
                            App.AxiosProvider.RegistrarBitacoraMov(tableInstance);
                            Toast.fire({ title: "Successfully saved!", icon: "success" })
                                .then(function () { return window.location.href = "Cliente/Grid"; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    }).catch(function (c) { return console.log(c); });
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
})(ClienteEdit || (ClienteEdit = {}));
//# sourceMappingURL=Edit.js.map