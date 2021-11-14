
namespace UsuariosEdit {


    interface UsuariosEdit {
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
            RegistraServicio(entity) {

                if (entity.UsuariosId == null) {
                    return App.AxiosProvider.UsuarioRegistrar(entity);
                } else {
                    return App.AxiosProvider.UsuarioActualizar(entity);
                }
            },
            Save() {

                if (BValidateData(this.Formulario)) {

                    Loading.fire("Saving...");
                    this.RegistraServicio(this.Entity).then(data => {

                        var mensaje = "";

                        if (data.CodeError == 0) {
                            var movimiento = "";

                            if (Entity.UsuariosId != null) {
                                movimiento = "The user " + Entity.UsuariosId + " has been updated";
                            } else {
                                movimiento = "A new user has been created";
                            }

                            const tableInstance: UsuariosEdit = {
                                UsuariosId: parseInt(SessionID),
                                DescripcionMovimiento: movimiento
                            };

                            App.AxiosProvider.RegistrarBitacoraMov(tableInstance);

                            Toast.fire({ title: "Successfully saved!", icon: "success" })
                                .then(() => window.location.href = "Usuario/UsuariosGrid")
                        } else {
                            Toast.fire({ title: data.MsgError, icon: "error" });

                        }


                    }).catch(c => console.log(c));

                    Loading.close();

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