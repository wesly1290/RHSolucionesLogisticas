"use strict";
var FacturasGrid;
(function (FacturasGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("You want to delete the record? ", "Delete", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                //animacion
                Loading.fire("Borrando..");
                App.AxiosProvider.FacturaEliminar(id).then(function (data) {
                    //cerrar animacion
                    Loading.close();
                    if (data.CodeError == 0) {
                        var movimiento = "The invoice " + id + " has been deleted";
                        var tableInstance = {
                            UsuariosId: parseInt(SessionID),
                            DescripcionMovimiento: movimiento
                        };
                        App.AxiosProvider.RegistrarBitacoraMov(tableInstance);
                        Toast.fire({ title: "Successfully deleted!", icon: "success" }).then(function () { return window.location.href = "Factura/FacturasGrid"; });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    FacturasGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(FacturasGrid || (FacturasGrid = {}));
//# sourceMappingURL=FacturasGrid.js.map