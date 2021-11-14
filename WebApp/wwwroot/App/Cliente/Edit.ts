

namespace ClienteEdit {

    interface ClienteEdit {
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



            ClienteServicio(entity) {
                console.log(entity);
                if (entity.ClientesId == null) {
                    return App.AxiosProvider.ClientesGuardar(entity);
                } else {
                    return App.AxiosProvider.ClientesActualizar(entity);
                }
            },
            Save() {

                if (BValidateData(this.Formulario)) {

                    Loading.fire("Saving...");

                    this.ClienteServicio(this.Entity).then(data => {

                        Loading.close();

                        if (data.CodeError == 0) {

                            var movimiento = "";

                            if (Entity.ClientesId != null) {
                                movimiento = "The customer " + Entity.ClientesId + " has been updated";
                            } else {
                                movimiento = "A new customer has been created";
                            }

                            const tableInstance: ClienteEdit = {
                                UsuariosId: parseInt(SessionID),
                                DescripcionMovimiento: movimiento
                            };

                            App.AxiosProvider.RegistrarBitacoraMov(tableInstance);

                            Toast.fire({ title: "Successfully saved!", icon: "success" })
                                .then(() => window.location.href = "Cliente/Grid")
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

        }

    });

    Formulario.$mount("#AppEdit")
}