Utilidades.Tag = Utilidades.Tag || {};

Utilidades.Tag = (function () {

    var TBL_TAGS = "#tag_tabla";

    function RecargarTabla() {
        var dt = $(TBL_TAGS).DataTable();
        dt.clear();
        dt.ajax.reload();
        dt.draw();
    }

    function CargarDataTable() {
        $(TBL_TAGS).DataTable();
    }

    function CargarEventos() {

    }

    function CargarFuncionalidades() {
        CargarDataTable();
    }

    function init() {
        CargarFuncionalidades();
        CargarEventos();
    }

    return {

        init: init
    }

})();