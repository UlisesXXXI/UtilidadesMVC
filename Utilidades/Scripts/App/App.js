var Utilidades = Utilidades || {};


Utilidades = (function () {

   var CargarSpinner = function () {
       console.log("Entre");
        var spinnerHtml = `<div class="background-container-spinner" style="display:none"  >
                    <div class="spinner" >
                    <div class="breeding-rhombus-spinner">
                    <div class="rhombus child-1"></div>
                    <div class="rhombus child-2"></div>
                    <div class="rhombus child-3"></div>
                    <div class="rhombus child-4"></div>
                    <div class="rhombus child-5"></div>
                    <div class="rhombus child-6"></div>
                    <div class="rhombus child-7"></div>
                    <div class="rhombus child-8"></div>
                    <div class="rhombus big"></div>
                    </div>
                    </div>
                </div>

                `
        $("body").append(spinnerHtml);

        $(".background-container-spinner").fadeIn(500);
    }

    var OcultarSpinner = function () {
        $(".background-container-spinner").fadeOut(500, function () {
            $(".background-container-spinner").remove();
        })
    }

    var CargarEventosBarraNavegador = function () {
        $('.navbar .navegacion').click(CargarSpinner);
       
    }
    var CargarDatatables = function () {
        $("[data-dt='true']").DataTable();
    }

    var CargarEventos = function () {
        CargarEventosBarraNavegador();
        console.log('Cargarevento');
    }

    var init = function () {
        CargarEventos();
        CargarDatatables();
    }

    return {
        init: init,
        CargarSpinner: CargarSpinner,
        OcultarSpinner: OcultarSpinner,
    }
})();

Utilidades.init();



