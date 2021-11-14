"use strict";
var ClienteGrid;
(function (ClienteGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("You want to delete the record? ", "Delete", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                //animacion
                Loading.fire("Deleting...");
                App.AxiosProvider.ClientesEliminar(id).then(function (data) {
                    //cerrar animacion
                    Loading.close();
                    if (data.CodeError == 0) {
                        var movimiento = "The customer " + id + " has been deleted";
                        var tableInstance = {
                            UsuariosId: parseInt(SessionID),
                            DescripcionMovimiento: movimiento
                        };
                        App.AxiosProvider.RegistrarBitacoraMov(tableInstance);
                        Toast.fire({ title: "Successfully deleted!", icon: "success" }).then(function () { return window.location.href = "Cliente/Grid"; });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    ClienteGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(ClienteGrid || (ClienteGrid = {}));
//# sourceMappingURL=Grid.js.map