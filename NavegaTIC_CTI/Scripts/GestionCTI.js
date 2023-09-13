var ciudades;
var departamentos;

$(document).ready(async function () {

    await llenarselect();

    const paramst = new URLSearchParams(window.location.search)
    var Id = paramst.get('Id');
    var Agente = paramst.get('Agente');
    var Telefono = paramst.get('Telefono');
    await loadForm(Id, Agente, Telefono)
})

async function llenarselect() {

    if (!departamentos) {
        await $.post('/Home/Departamentos', {}, function (respuesta) {
            departamentos = JSON.parse(respuesta);
        }, "json");

        await $.post('/Home/Municipios', {}, function (respuesta) {
            ciudades = JSON.parse(respuesta);

            setTimeout(async function () {
                if (ciudades !== undefined) {
                    await BEN_loadDepartamentos();
                    await INST_loadDepartamentos();
                }
            }, 2000);
        }, "json");
    }
    else {
        if (ciudades !== undefined) {
            await BEN_loadDepartamentos();
            await INST_loadDepartamentos();
        }
    }

    

    //await $.postJSON("/Home/Departamentos", async function (data) {
    //    departamentos = data;
    //});

    //await $.getJSON("/Home/Municipios", async function (data) {
    //    ciudades = data;
    //    setTimeout(function () {
    //        if (ciudades !== undefined) {
    //            BEN_loadDepartamentos();
    //            INST_loadDepartamentos();
    //        }
    //    }, 2000);
    //})
}


function changeDepartamento() {
    var departamentoId = $("#txt_BEN_DEPARTAMENTO").val();
    BEN_loadCiudades(departamentoId);
}
function changedepartamentosinst() {
    var departamentoId = $("#txt_BEN_INST_DEPARTAMENTO").val();
    INST_loadCiudades(departamentoId);

}

var BEN_loadDepartamentos = async function (defaultDep) {
    if ($("#txt_BEN_DEPARTAMENTO").val() && !defaultDep) {

    }
    else {
        $("#txt_BEN_DEPARTAMENTO").empty();
        $("#txt_BEN_DEPARTAMENTO").append('<option value="" ></option>');
        $.each(departamentos, function (i, valor) {
            if (defaultDep && defaultDep.toUpperCase() == valor.nombreDepartamento.toUpperCase()) {
                $("#txt_BEN_DEPARTAMENTO").append("<option selected='selected' value='" + valor.nombreDepartamento.toUpperCase() + "'>" + valor.nombreDepartamento.toUpperCase() + "</option>");
            }
            else {
                $("#txt_BEN_DEPARTAMENTO").append("<option value='" + valor.nombreDepartamento.toUpperCase() + "'>" + valor.nombreDepartamento.toUpperCase() + "</option>");
            }
        });
    }
   
};

var BEN_loadCiudades = function (departamentoId, defaultDep) {
    var ciudadesDepto = searchIntoJson(ciudades, "departamentoId", departamentoId.toUpperCase() );
    $("#txt_BEN_CIUDAD").empty();
    $("#txt_BEN_CIUDAD").append('<option value="" ></option>');
    $.each(ciudadesDepto, function (i, valor) {
        if (defaultDep && defaultDep.toUpperCase() == valor.nombreCiudad.toUpperCase()) {
            $("#txt_BEN_CIUDAD").append('<option selected="selected"  value="' + valor.nombreCiudad.toUpperCase() + '">' + valor.nombreCiudad.toUpperCase() + '</option>');
        }
        else
            $("#txt_BEN_CIUDAD").append('<option value="' + valor.nombreCiudad.toUpperCase() + '">' + valor.nombreCiudad.toUpperCase()  + '</option>');
    });
};

var INST_loadDepartamentos = async function (defaultDep) {

    if ($("#txt_BEN_INST_DEPARTAMENTO").val() && !defaultDep) {

    }
    else {
        $("#txt_BEN_INST_DEPARTAMENTO").empty();
        $("#txt_BEN_INST_DEPARTAMENTO").append('<option value="" ></option>');
        $.each(departamentos, function (i, valor) {
            if (defaultDep && defaultDep.toUpperCase() == valor.nombreDepartamento.toUpperCase()) {
                $("#txt_BEN_INST_DEPARTAMENTO").append("<option selected='selected' value='" + valor.nombreDepartamento.toUpperCase() + "'>" + valor.nombreDepartamento.toUpperCase() + "</option>");
            }
            else {
                $("#txt_BEN_INST_DEPARTAMENTO").append("<option value='" + valor.nombreDepartamento.toUpperCase() + "'>" + valor.nombreDepartamento.toUpperCase() + "</option>");
            }
        });
    }    
};

var INST_loadCiudades = function (departamentoId, defaultDep) {
    var ciudadesDepto = searchIntoJson(ciudades, "departamentoId", departamentoId.toUpperCase());
    $("#txt_BEN_INST_CIUDAD").empty();
    $("#txt_BEN_INST_CIUDAD").append('<option value="" ></option>');
    $.each(ciudadesDepto, function (i, valor) {
        if (defaultDep && defaultDep.toUpperCase() == valor.nombreCiudad.toUpperCase()) {
            $("#txt_BEN_INST_CIUDAD").append('<option selected="selected"  value="' + valor.nombreCiudad.toUpperCase() + '">' + valor.nombreCiudad.toUpperCase() + '</option>');
        }
        else
            $("#txt_BEN_INST_CIUDAD").append('<option value="' + valor.nombreCiudad.toUpperCase() + '">' + valor.nombreCiudad.toUpperCase() + '</option>');
    });
};

async function Buscar($btn) {
    var value = $("#txtBuscar").val();


    await loadForm(null, null, value)
}

var searchIntoJson = function (obj, column, value) {
    var results = [];
    var valueField;
    var searchField = column;
    for (var i = 0; i < obj.length; i++) {
        valueField = obj[i][searchField].toString().toUpperCase() ;
        if (valueField === value.toUpperCase() ) {
            results.push(obj[i]);
        }
    }
    return results;
};

async function loadForm(Id, Agente, Telefono) {
    let params = new Object();
    params['Id'] = Id;
    params['Agente'] = Agente;
    params['Telefono'] = Telefono;

    let getPartialView = async (Method, params) => await $.ajax({
        type: "post",
        url: '/Home/' + Method,
        data: params ? params : null
    })

    $("#ContentForm").html('cargando...');

    $("#ContentForm").html(await getPartialView('Formulario', params));
    await llenarselect();

    await renderform();
}

function changeTipificacion(value) {
    refreshTificacion2(value);
}

function refreshTificacion2(val, selected) {
    $('#txt_Tipificacion2').html("Cargando..");
    fetch("/Home/Tipificacion2?clave=" + val)
        .then(function (result) {
            if (result.ok) {
                return result.json();
            }
        })
        .then(function (data) {
            $('#txt_Tipificacion2').html("");

            data.forEach(function (element) {

                if (selected && selected == element.Value) {
                    $('#txt_Tipificacion2').append(`<option value="${element.Value}" selected>
                                             ${element.Text}
                                                </option>`);
                }
                else {
                    $('#txt_Tipificacion2').append(`<option value="${element.Value}">
                                             ${element.Text}
                                                </option>`);
                }
            })
        })
}

async function  renderform() {

    //Tipificacion
    let tipi1 = $('#txt_Tipificacion1').val();
    let tipi2 = $('#txt_Tipificacion2_Hidden').val();

    if (tipi1) {
        refreshTificacion2(tipi1, tipi2)
    }

    //Es menor
    let valoresmenor = $("#txt_ES_MENOR").val();
    changeMenor(valoresmenor);

    //equipo4g
    let equipo = $("#txt_BEN_EQUIPO4G").val();
    esquipo4GChange(equipo);

    //servicioActivoChange
    let servicio = $("#txt_BEN_SERVICIOS_ACTIVOS").val()
    servicioActivoChange(servicio)


    //BEN_departamento - ciudad
    let ben_departamento = $('#txt_BEN_DEPARTAMENTO_HIDEN').val();
    let ben_ciudad = $('#txt_BEN_CIUDAD_HIDEN').val();

    if (ben_departamento)
        await BEN_loadDepartamentos(ben_departamento);

    if (ben_ciudad)
        BEN_loadCiudades(ben_departamento, ben_ciudad)

    //insst_departamento - ciudad
    let inst_departamento = $('#txt_BEN_INST_DEPARTAMENTO_HIDEN').val();
    let inst_ciudad = $('#txt_BEN_INST_CIUDAD_HIDEN').val();

    if (inst_departamento)
        await INST_loadDepartamentos(inst_departamento);

    if (inst_ciudad)
        INST_loadCiudades(inst_departamento, inst_ciudad)

}
function changeMenor(value) {
    if (value == "SI") {
        $("#formRepresentante").addClass("show")
        $("#formRepresentante").removeClass("hidden")

    }
    else {
        $("#formRepresentante").removeClass("show")
        $("#formRepresentante").addClass("hidden")

    }
}

function esquipo4GChange(value) {
    if (value == "SI") {
        $("#form4G").addClass("show")
        $("#form4G").removeClass("hidden")

    }
    else {
        $("#form4G").removeClass("show")
        $("#form4G").addClass("hidden")

    }
}

function servicioActivoChange(value) {
    if (value == "SI") {
        $("#formServicioActivo").removeClass("show")
        $("#formServicioActivo").addClass("hidden")
    }
    else {
      
        $("#formServicioActivo").addClass("show")
        $("#formServicioActivo").removeClass("hidden")

    }
}
async function Guardar($Btn) {
    try {
        ToolsFuncBtnLoader($Btn, 1);

        let params = new Object();

        params["ID"] = $("#Id").val();
        params["IdAgente"] = $("#IdAgente").val();
        params["BEN_PRIMER_NOMBRE"] = $("#txt_BEN_PRIMER_NOMBRE").val();
        params["BEN_SEGUNDO_NOMBRE"] = $("#txt_BEN_SEGUNDO_NOMBRE").val();
        params["BEN_PRIMER_APELLIDO"] = $("#txt_BEN_PRIMER_APELLIDO").val();
        params["BEN_SEGUNDO_APELLIDO"] = $("#txt_BEN_SEGUNDO_APELLIDO").val();
        params["BEN_TIPO_DOCUMENTO"] = $("#txt_BEN_TIPO_DOCUMENTO").val();
        params["BEN_DOCUMENTO"] = $("#txt_BEN_DOCUMENTO").val();
        params["BEN_FECHA_NACIMIENTO"] = $("#txt_BEN_FECHA_NACIMIENTO").val();
        params["BEN_FECHA_EXPEDICION"] = $("#txt_BEN_FECHA_EXPEDICION").val();
        params["BEN_CORREO"] = $("#txt_BEN_CORREO").val();
        params["BEN_TELEFONO1"] =  $("#txt_BEN_TELEFONO1").val();
        params["BEN_TELEFONO2"] = $("#txt_BEN_TELEFONO2").val();
        params["BEN_TELEFONO3"] = $("#txt_BEN_TELEFONO3").val();
        params["BEN_DIRECCION"] = $("#txt_BEN_DIRECCION").val();
        params["BEN_DEPARTAMENTO"] = $("#txt_BEN_DEPARTAMENTO").val();
        params["BEN_CIUDAD"] = $("#txt_BEN_CIUDAD").val();
        params["BEN_BARRIO_O_VEREDA"] = $("#txt_BEN_BARRIO_O_VEREDA").val();
        params["BEN_CODIGO_DANE"] = $("#txt_BEN_CODIGO_DANE").val();
        params["BEN_ESTRATO"] = $("#txt_BEN_ESTRATO").val();
        params["BEN_EQUIPO4G"] = $("#txt_BEN_EQUIPO4G").val();
        params["BEN_SERVICIOS_ACTIVOS"] = $("#txt_BEN_SERVICIOS_ACTIVOS").val();
        params["BEN_PAGARIA_SIM"] = $("#txt_BEN_PAGARIA_SIM").val();
        params["BEN_CONFIRMA_PAGARIA_SIM"] = $("#txt_BEN_CONFIRMA_PAGARIA_SIM").val();
        params["BEN_INSTITUCION_EDUCATIVA"] = $("#txt_BEN_INSTITUCION_EDUCATIVA").val();
        params["BEN_INST_DIRECCION"] = $("#txt_BEN_INST_DIRECCION").val();
        params["BEN_INST_DEPARTAMENTO"] = $("#txt_BEN_INST_DEPARTAMENTO").val();
        params["BEN_INST_CIUDAD"] =  $("#txt_BEN_INST_CIUDAD").val();
        params["BEN_INST_CODIGO_DANE"] = $("#txt_BEN_INST_CODIGO_DANE").val();
        params["BEN_NIVEL_ESCOLAR"] = $("#txt_BEN_NIVEL_ESCOLAR").val();
        params["BEN_TIEMPO_FALTANTE"] = $("#txt_BEN_TIEMPO_FALTANTE").val();
        params["ES_MENOR"] = $("#txt_ES_MENOR").val();
        params["REPRE_PRIMER_NOMBRE"] = $("#txt_REPRE_PRIMER_NOMBRE").val();
        params["REPRE_SEGUNDO_NOMBRE"] = $("#txt_REPRE_SEGUNDO_NOMBRE").val();
        params["REPRE_PRIMER_APELLIDO"] =  $("#txt_REPRE_PRIMER_APELLIDO").val();
        params["REPRE_SEGUNDO_APELLIDO"] = $("#txt_REPRE_SEGUNDO_APELLIDO").val();
        params["REPRE_TIPO_DOCUMENTO"] =  $("#txt_REPRE_TIPO_DOCUMENTO").val();
        params["REPRE_DOCUMENTO"] = $("#txt_REPRE_DOCUMENTO").val();
        params["REPRE_PARENTESCO"] = $("#txt_REPRE_PARENTESCO").val();
        params["REPRE_DIRECCION"] = $("#txt_REPRE_DIRECCION").val();
        params["REPRE_DEPARTAMENTO"] = $("#txt_REPRE_DEPARTAMENTO").val();
        params["REPRE_MUNICIPIO"] = $("#txt_REPRE_MUNICIPIO").val();
        params["REPRE_COD_DANE"] = $("#txt_REPRE_COD_DANE").val();
        params["REPRE_BARRIO"] = $("#txt_REPRE_BARRIO").val();
        params["REPRE_CORREO"] = $("#txt_REPRE_CORREO").val();
        params["Tipificacion1"] = $("#txt_Tipificacion1").val();
        params["Tipificacion2"] =  $("#txt_Tipificacion2").val();
        params["En_3DIAS"] = $("#txt_3dias").val();
        params["FECHA_ATENCION"] = $("#txt_FECHA_ATENCION").val();
        params["DIRECCION_ENTREGA"] = $("#txt_DIRECCION_ENTREGA").val();

        await $.ajax({
            type: "post",
            url: '/Home/Guardar',
            data: params ? params : null
        })

        alert("Guardado exitoso")


    }
    catch (ex) {
        alert("Ocurrio un error al guardar, COntacte el administrador")

    }
    finally {
        ToolsFuncBtnLoader($Btn, 1)

    }

}

function ToolsFuncBtnLoader($Btn, Ocultar) {
    if (Ocultar == 1) {
        if ($Btn) {
            $Btn.style.display = 'none'
            $('#' + $Btn.id + '-load').show()
        }

    } else {
        if ($Btn) {
            $Btn.style.display = ''
            $('#' + $Btn.id + '-load').hide()
        }

    }
}