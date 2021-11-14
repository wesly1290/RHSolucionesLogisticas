"use strict";
var UsuariosGrid;
(function (UsuariosGrid) {
    function OnClickEliminar(id) {
        var ttype = ' @HttpContext.Current.Session["TestType"] ';
        console.log(ttype);
        ComfirmAlert("You want to delete the record? ", "Delete user", "warning", "#3085d6", "#d33")
            .then(function (result) {
            if (result.isConfirmed) {
                //animacion
                Loading.fire("Deleting..");
                App.AxiosProvider.UsuarioEliminar(id).then(function (data) {
                    //cerrar animacion
                    Loading.close();
                    if (data.CodeError == 0) {
                        var movimiento = "The user " + id + " has been deleted";
                        var tableInstance = {
                            UsuariosId: parseInt(SessionID),
                            DescripcionMovimiento: movimiento
                        };
                        App.AxiosProvider.RegistrarBitacoraMov(tableInstance);
                        Toast.fire({ title: "Successfully deleted!", icon: "success" }).then(function () { return window.location.href = "Usuario/UsuariosGrid"; });
                    }
                    else {
                        Loading.close();
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    UsuariosGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(UsuariosGrid || (UsuariosGrid = {}));
//# sourceMappingURL=UsuariosGrid.js.map