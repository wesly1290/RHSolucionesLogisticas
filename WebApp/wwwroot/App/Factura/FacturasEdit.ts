

namespace FacturaEdit {

    interface FacturaEdit {
        UsuariosId: number;
        DescripcionMovimiento: string;
    }

    declare var SessionID: any;

    var Entity = $("#AppEdit").data("entity");

    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,

        },

        methods: {

            CalculoMontoTotalFn() {
                var total = ((this.Entity.Impuesto / 100) * this.Entity.Monto) + this.Entity.Monto;
                return total;
            },


            FacturaServicio(entity) {

                if (entity.IdFactura == null) {
                    return App.AxiosProvider.FacturaGuardar(entity);
                } else {
                    return App.AxiosProvider.FacturaActualizar(entity);
                }
            },
            Save() {

                if (BValidateData(this.Formulario)) {

                    Loading.fire("Saving");
                    this.FacturaServicio(this.Entity).then(data => {

                        Loading.close();

                        if (data.CodeError == 0) {

                            var movimiento = "";

                            if (Entity.IdFactura != null) {
                                movimiento = "The invoice " + Entity.IdFactura + " has been updated";
                            } else {
                                movimiento = "A new invoice has been created";
                            }

                            const tableInstance: FacturaEdit = {
                                UsuariosId: parseInt(SessionID),
                                DescripcionMovimiento: movimiento
                            };

                            App.AxiosProvider.RegistrarBitacoraMov(tableInstance);

                            Toast.fire({ title: "Successfully saved!", icon: "success" })
                                .then(() => window.location.href = "Factura/FacturasGrid")
                        } else {
                            Toast.fire({ title: data.MsgError, icon: "error" });

                        }


                    }).catch(c => console.log(c));



                } else {
                    Toast.fire({ title: "Please complete the required fields!", icon: "error" });
                }

            }


        },
        mounted() {


            CreateValidator(this.Formulario);

        },

        computed: {
            CalculoMontoTotalCP: function (): number {
                var total = ((this.Entity.Impuesto / 100) * this.Entity.Monto) + this.Entity.Monto;
                return total;
            }
        }

    });

    Formulario.$mount("#AppEdit")
}