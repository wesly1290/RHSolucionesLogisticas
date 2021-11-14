namespace RolesGrid {

    interface RolesEdit {
        UsuariosId: number;
        DescripcionMovimiento: string;
    }

    declare var SessionID: any;

    export function OnClickEliminar(id) {
        ComfirmAlert("You want to delete the record? ", "Delete", "warning", "#3085d6", "#d33")
            .then(result => {
                if (result.isConfirmed) {
                    //animacion
                    Loading.fire("Deleting...");

                    App.AxiosProvider.RolEliminar(id).then(data => {
                        //cerrar animacion
                        Loading.close();

                        if (data.CodeError == 0) {

                            var movimiento = "The role " + id + " has been deleted";

                            const tableInstance: RolesEdit = {
                                UsuariosId: parseInt(SessionID),
                                DescripcionMovimiento: movimiento
                            };

                            App.AxiosProvider.RegistrarBitacoraMov(tableInstance);

                            Toast.fire({ title: "Successfully deleted!", icon: "success" }).then(() => window.location.href = "Roles/RolesGrid");
                        } else {
                            Toast.fire({ title: data.MsgError, icon: "error" })
                        }


                    });

                }

            });


    }

    $("#GridView").DataTable();

}