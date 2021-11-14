"use strict";
var Registrarse;
(function (Registrarse) {
    var Entity = $("#AppRegistrar").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FromRegistrarse",
            Entity: Entity,
        },
        methods: {
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Registering...");
                    App.AxiosProvider.UsuarioRegistrar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            window.location.href = "../Login";
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    });
                }
                else {
                    Toast.fire({ title: "Please complete the required fields!", icon: "error" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    $("#GridView").DataTable();
    Formulario.$mount("#AppRegistrar");
})(Registrarse || (Registrarse = {}));
//# sourceMappingURL=Registrarse.js.map