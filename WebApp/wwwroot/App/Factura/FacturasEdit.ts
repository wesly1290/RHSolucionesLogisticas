

namespace FacturaEdit {


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

                if (entity.IdAFactura == null) {
                    return App.AxiosProvider.FacturaGuardar(entity);
                } else {
                    return App.AxiosProvider.FacturaActualizar(entity);
                }
            },
            Save() {

                if (BValidateData(this.Formulario)) {

                    Loading.fire("Guardando");
                    this.FacturaServicio(this.Entity).then(data => {

                        Loading.close();

                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardo sastifactoriamente!", icon: "success" })
                                .then(() => window.location.href = "Factura/FacturasGrid")
                        } else {
                            Toast.fire({ title: data.MsgError, icon: "error" });

                        }


                    }).catch(c => console.log(c));



                } else {
                    Toast.fire({ title: "Por favor complete los campos requeridos!", icon: "error" });
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