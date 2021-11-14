
namespace RolesEdit {

    interface PermisosPaginaEdit {
        RolesId: number;
        PaginasId: number;
        Check: boolean;
    }

    interface RolesEdit {
        UsuariosId: number;
        DescripcionMovimiento: string;
    }

    declare var SessionID: any;

    var Entity = $("#AppEdit").data("entity");
    var Rights = $("#Rights").data("entity");

    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity,

        },

        methods: {
            RegistraServicio(entity) {

                if (entity.RolesId == null) {
                    return App.AxiosProvider.RolGuardar(entity);
                } else {
                    return App.AxiosProvider.RolActualizar(entity);
                }
            },
            Save() {

                if (BValidateData(this.Formulario)) {

                    Loading.fire("Saving...");
                    this.RegistraServicio(this.Entity).then(data => {

                        var mensaje = "";

                        if (data.CodeError == 0) {

                            var roleid = 0;
                            if (this.Entity.RolesId == null) {
                                roleid = data.RegisterId
                            } else
                                roleid = this.Entity.RolesId;

                            var checked, permiso;

                            $('#Rights input[type=checkbox]').each(function () {
                                if ($(this).prop('checked')) {
                                    checked = true;
                                } else {
                                    checked = false;
                                }

                                permiso = $(this).val();

                                RegistraPermisoPagina(roleid, checked, parseInt(permiso)).then(data => {


                                    if (data.CodeError == 0) {

                                    } else {
                                        mensaje += data.MsgError + "<br>";
                                    }


                                }).catch(c => console.log(c));

                            });
                            if (mensaje == "") {

                                var movimiento = "";

                                if (Entity.RolesId != null) {
                                    movimiento = "The role " + Entity.RolesId + " has been updated";
                                } else {
                                    movimiento = "A new role has been created";
                                }

                                const tableInstance: RolesEdit = {
                                    UsuariosId: parseInt(SessionID),
                                    DescripcionMovimiento: movimiento
                                };

                                App.AxiosProvider.RegistrarBitacoraMov(tableInstance);

                                Toast.fire({ title: "Successfully saved!", icon: "success" })
                                    .then(() => window.location.href = "Roles/RolesGrid")
                            } else
                                Toast.fire({ title: "Errors occurred while saving " + mensaje, icon: "error" });

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

    export function CheckAll() {
        $('#Rights input[type=checkbox]').each(function () {
            if ($('#AllRight').prop('checked')) {
                $(this).prop('checked', true);
            } else {
                $(this).prop('checked', false);
            }
        });
    }


    export function RegistraPermisoPagina(roleid, checked, permiso) {

        const tableInstance: PermisosPaginaEdit = {
            RolesId: roleid,
            PaginasId: permiso,
            Check: checked,
        };


        return App.AxiosProvider.RolPaginaGuardar(tableInstance);
    }

    Formulario.$mount("#AppEdit")

    window.onload = () => {
        console.log("ONLOAD");
        var Entity = $("#AppEdit").data("entity");
        var Rights = $("#Rights").data("entity");
        if (Rights.length > 0) {
            CheckRight(Rights);
        }
    };

    export function CheckRight(Rights) {

        $('#Rights input[type=checkbox]').each(function () {
            for (var i = 0; i < Rights.length; i++) {
                if ($(this).val() == Rights[i].PaginasId) {
                    $(this).prop('checked', true);
                }
            }
        });
    }
}