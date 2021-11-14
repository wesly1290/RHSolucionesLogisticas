"use strict";
var FacturaEdit;
(function (FacturaEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,
        },
        methods: {
            CalculoMontoTotalFn: function () {
                var total = ((this.Entity.Impuesto / 100) * this.Entity.Monto) + this.Entity.Monto;
                return total;
            },
            FacturaServicio: function (entity) {
                if (entity.IdFactura == null) {
                    return App.AxiosProvider.FacturaGuardar(entity);
                }
                else {
                    return App.AxiosProvider.FacturaActualizar(entity);
                }
            },
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Saving");
                    this.FacturaServicio(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            var movimiento = "";
                            if (Entity.IdFactura != null) {
                                movimiento = "The invoice " + Entity.IdFactura + " has been updated";
                            }
                            else {
                                movimiento = "A new invoice has been created";
                            }
                            var tableInstance = {
                                UsuariosId: parseInt(SessionID),
                                DescripcionMovimiento: movimiento
                            };
                            App.AxiosProvider.RegistrarBitacoraMov(tableInstance);
                            Toast.fire({ title: "Successfully saved!", icon: "success" })
                                .then(function () { return window.location.href = "Factura/FacturasGrid"; });
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
        },
        computed: {
            CalculoMontoTotalCP: function () {
                var total = ((this.Entity.Impuesto / 100) * this.Entity.Monto) + this.Entity.Monto;
                return total;
            }
        }
    });
    Formulario.$mount("#AppEdit");
})(FacturaEdit || (FacturaEdit = {}));
//# sourceMappingURL=FacturasEdit.js.map