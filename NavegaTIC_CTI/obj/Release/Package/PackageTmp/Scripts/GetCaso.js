var ciudades;
var departamentos;

$(document).ready(async function () {

    await llenarselect();

    const paramst = new URLSearchParams(window.location.search)
    var Id = paramst.get('Id');
    var Agente = paramst.get('Agente');
    var Telefono = paramst.get('Telefono');
    //await loadForm(Id, Agente, Telefono)
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
    var ciudadesDepto = searchIntoJson(ciudades, "departamentoId", departamentoId.toUpperCase());
    $("#txt_BEN_CIUDAD").empty();
    $("#txt_BEN_CIUDAD").append('<option value="" ></option>');
    $.each(ciudadesDepto, function (i, valor) {
        if (defaultDep && defaultDep.toUpperCase() == valor.nombreCiudad.toUpperCase()) {
            $("#txt_BEN_CIUDAD").append('<option selected="selected"  value="' + valor.nombreCiudad.toUpperCase() + '">' + valor.nombreCiudad.toUpperCase() + '</option>');
        }
        else
            $("#txt_BEN_CIUDAD").append('<option value="' + valor.nombreCiudad.toUpperCase() + '">' + valor.nombreCiudad.toUpperCase() + '</option>');
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
        valueField = obj[i][searchField].toString().toUpperCase();
        if (valueField === value.toUpperCase()) {
            results.push(obj[i]);
        }
    }
    return results;
};

/*async function loadForm(Id, Agente, Telefono) {
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
}*/
function validarescal() {
    let escal = $('#escalamiento').val();
    if (escal == "No") {
        $('#escaladoa').val('');
        $('#fescalamiento').val('');
        $('#rescalamiento').val('');
        $('#escaladoa').attr("disabled", true);
        $('#fescalamiento').attr("disabled", true);
        $('#rescalamiento').attr("disabled", true);
        $('#rtae').css("display", "none");
        $('#escal').css("display", "none");
        $('#enviarcorreo').css("display", "none");
    } else {
        $('#escaladoa').attr("disabled", false);
        $('#rtae').css("display", "");
        $('#escal').css("display", "");
        // $('#fescalamiento').attr("disabled", false);
        // $('#rescalamiento').attr("disabled", false);

    }
}

function changeCategoria(value, cargo) {
    refreshsubcategoria(value, 0, cargo);
}
function changeCategoria_aibt(value) {
    refreshsubcategoria_aibt(value, 0);
}
function changeSubCategoria(value) {
    refreshdetalle(value);
}
function refreshdetalle(val, selected,) {
    let ccosto = $('#CostoId').val().toUpperCase();

    $('#detalle').html("Cargando..");
    $('#detalle').append(`<option value="" selected>
                                             Seleccione...
                                                </option>`);
    fetch("/Home/Detalle?clave=" + val)
        .then(function (result) {
            if (result.ok) {
                return result.json();
            }
        })
        .then(function (data) {
            $('#detalle').html("");

            data.forEach(function (element) {
                //if (element)
                console.log("entro");
                if (val == 33) {
                    var searchcosto = ccosto.indexOf(element.Campaña.toUpperCase());
                    if (searchcosto >= 0) {
                        if (selected && selected == element.Value) {

                            $('#detalle').append(`<option value="${element.DetalleName}" selected>
                                             ${element.DetalleName}
                                                </option>`);
                        }
                        else {
                            $('#detalle').append(`<option value="${element.DetalleName}">
                                             ${element.DetalleName}
                                                </option>`);
                        }
                    }
                } else {
                    if (selected && selected == element.Value) {

                        $('#detalle').append(`<option value="${element.DetalleName}" selected>
                                             ${element.DetalleName}
                                                </option>`);
                    }
                    else {
                        $('#detalle').append(`<option value="${element.DetalleName}">
                                             ${element.DetalleName}
                                                </option>`);
                    }
                }

            })
        })
    if (val == 34 || val == 36) {

        //$('#subcategoria').attr("disabled", true);
        $('#detalle').css("display", "none");
        $('#detalle2').css("display", "");
        $('#detalle2').attr("required", true);

    } else {
        //$('#subcategoria').attr("disabled", false);
        $('#detalle').css("display", "");
        $('#detalle2').css("display", "none");

    }
}
function refreshubicacion(val, selected) {
    $('#ubicacion').html("Cargando..");

    fetch("/Home/Ubicacion?clave=" + val)
        .then(function (result) {
            if (result.ok) {
                return result.json();
            }
        })
        .then(function (data) {
            $('#ubicacion').html("");
            $('#ubicacion').append(`<option value="" selected>
                                             Seleccione...
                                                </option>`);



            data.forEach(function (element) {

                //if (element)

                if (selected && selected == element.Value) {
                    $('#ubicacion').append(`<option value="${element.UbicacionName}" selected>
                                                     ${element.UbicacionName}
                                                        </option>`);
                }
                else {
                    $('#ubicacion').append(`<option value="${element.UbicacionName}">
                                                     ${element.UbicacionName}
                                                        </option>`);
                }



            })
        })

}
function refreshsubcategoria(val, selected, cargo) {
    $('#subcategoria').html("Cargando..");
    var validatecargo = cargo.indexOf("GERENTE");
    fetch("/Home/Subcategoria?clave=" + val)
        .then(function (result) {
            if (result.ok) {
                return result.json();
            }
        })
        .then(function (data) {
            $('#subcategoria').html("");
            $('#subcategoria').append(`<option value="" selected>
                                             Seleccione...
                                                </option>`);
            $('#detalle').html("");


            data.forEach(function (element) {

                //if (element)
                if (element.SubcategoriaId == 34) {
                    if (validatecargo >= 0) {
                        if (selected && selected == element.Value) {
                            $('#subcategoria').append(`<option value="${element.SubcategoriaId}" selected>
                                                     ${element.SubcategoriaName}
                                                        </option>`);
                        }
                        else {
                            $('#subcategoria').append(`<option value="${element.SubcategoriaId}">
                                                     ${element.SubcategoriaName}
                                                        </option>`);
                        }
                    }
                } else {
                    if (selected && selected == element.Value) {
                        $('#subcategoria').append(`<option value="${element.SubcategoriaId}" selected>
                                                     ${element.SubcategoriaName}
                                                        </option>`);
                    }
                    else {
                        $('#subcategoria').append(`<option value="${element.SubcategoriaId}">
                                                     ${element.SubcategoriaName}
                                                        </option>`);
                    }

                }

            })
        })
    if (val == 20) {

        $('#subcategoria').attr("disabled", true);
        $('#detalle').attr("disabled", true);

    } else {
        $('#subcategoria').attr("disabled", false);
        $('#detalle').attr("disabled", false);

    }
}
function refreshsubcategoria_aibt(val, selected) {
    var e = document.getElementById("categoria");
    var namecategory = e.options[e.selectedIndex].text;
    $('#NameCategory').val(namecategory);
    if (val == 495) {
        $('#subcategoria').css("display", "none");
    } else {
        $('#subcategoria').html("Cargando..");

        fetch("/FormularioContacto/Subcategoria_aib?clave=" + val)
            .then(function (result) {
                if (result.ok) {
                    return result.json();
                }
            })
            .then(function (data) {
                $('#subcategoria').html("");
                $('#subcategoria').append(`<option value="" selected>
                                             Seleccione...
                                                </option>`);
                $('#detalle').html("");


                data.forEach(function (element) {

                    //if (element)

                    $('#subcategoria').css("display", "");
                    if (selected && selected == element.Value) {
                        $('#subcategoria').append(`<option value="${element.SubcategoriaId}" selected>
                                                     ${element.SubcategoriaName}
                                                        </option>`);
                    }
                    else {
                        $('#subcategoria').append(`<option value="${element.SubcategoriaId}">
                                                     ${element.SubcategoriaName}
                                                        </option>`);
                    }




                })
            })
    }

}
function selectnamesubca() {
    var e = document.getElementById("subcategoria");
    var namesubcategory = e.options[e.selectedIndex].text;
    $('#NameSubCategory').val(namesubcategory);

}
function refreshcategoria_aibt(val, selected) {
    $('#categoria').html("Cargando..");
    $('#Group').val(val);

    $('#tipificacion_aibt').css("display", "");
    fetch("/FormularioContacto/Categoria_aib?clave=" + val)
        .then(function (result) {
            if (result.ok) {
                return result.json();
            }
        })
        .then(function (data) {
            $('#categoria').html("");
            $('#categoria').append(`<option value="" selected>
                                             Seleccione...
                                                </option>`);

            $('#subcategoria').html("");
            $('#subcategoria').append(`<option value="" selected>
                                             Seleccione...
                                                </option>`);

            data.forEach(function (element) {

                //if (element)

                if (selected && selected == element.Value) {
                    $('#categoria').append(`<option value="${element.CategoriaId}" selected>
                                                     ${element.CategoriaName}
                                                        </option>`);
                }
                else {
                    $('#categoria').append(`<option value="${element.CategoriaId}">
                                                     ${element.CategoriaName}
                                                        </option>`);
                }




            })
        })

}
function cerrado(val) {
    var sla = 0;
    console.log(val);
    console.log(sla);

    if (val != 'Cerrado\n') {
        $('#lsol').css("display", "none");
        $('#fsol').css("display", "none");
        $('#ans1').css("display", "none");
        $('#ans2').css("display", "none");


    } else {
        $('#lsol').css("display", "");
        $('#fsol').css("display", "");
        $('#ans1').css("display", "");
        $('#ans2').css("display", "");
        sla = valorsla();
        
    }
}
function hora(canthour) {
    canthour = parseInt(canthour);
    var fsolucion = $("#fsolucion").val();
    var freporte = $("#FechaSolicitud").val();
    var today = new Date(freporte);
    var endDate = new Date(fsolucion);
    var days = parseInt((endDate - today) / (1000 * 60 * 60 * 24));
    var hours = parseInt(days * 24) + parseInt(Math.abs(endDate - today) / (1000 * 60 * 60) % 24);
    var minutes = parseInt(Math.abs(endDate.getTime() - today.getTime()) / (1000 * 60) % 60);
    var seconds = parseInt(Math.abs(endDate.getTime() - today.getTime()) / (1000) % 60);
    // Compose the string for display
    var valuetotal = hours + (minutes / 60) + (seconds / 3600);
    var color = "red";
    if (valuetotal <= canthour) {
        color = "green";
    } else if (valuetotal <= (canthour + 1)) {
        color = "orange";
    } else {
        color = "red";
    }
    if (hours <= 9) {
        hours = "0" + hours;
    }
    if (minutes <= 9) {
        minutes = "0" + minutes;
    }
    if (seconds <= 9) {
        seconds = "0" + seconds;
    }
    var currentTimeString =/* days + "dia(s) " +*/hours + ":" + minutes + ":" + seconds;
    //$(".clock").html(currentTimeString);
    $("#ans").css({ "background-color": color, "color": "white" });
    $("#ans").val(currentTimeString);
}
function valorsla() {
    var categoryid = $("#categoria").val();
    var areaid = $("#escaladoa").val();
    var resulta = 0;
    $.ajax({
        type: "GET",
        url: "/Home/GetSla",
        data: ({ category: categoryid, area: areaid }),
        dataType: "html",
        success: function (data) {
            console.log(data);
            hora(data);
            return data;
        },
        error: function () {
            alert('Error occured');
        }
    });/*
    fetch("/Home/GetSla?category=" + categoryid + "&area=" + areaid)
        .then(function (result) {
            if (result.ok) {
                return result.json();
            }
        })
        .then(function (data) {
            data.forEach(function (element) {
                resulta = element;
              })
        })
    return resulta;*/
}
function listcorreos(val) {
    var list = "";
    fetch("/Home/listcorreos?clave=" + val)
        .then(function (result) {
            if (result.ok) {
                return result.json();
                console.log(result.json());
            }
        })
    
        .then(function (data) {
            data.forEach(function (element) {
                list = element.NameEscaladoACorreo + ";" + list;
                $('#Correos').val(list);
            })
        })
    let date = new Date()

    let day = date.getDate()
    let month = date.getMonth() + 1
    let year = date.getFullYear()
    var hoy2 = "";
    var m = "";
    var di = "";
    if (month < 10) {
        m = "0";
    } else {
        m = "";
    }
    if (day < 10) {
        di = "0";
    } else {
        di = "";
    }

    hoy2 = (`${year}-${m + month}-${di + day}`)
    $('#fescalamiento').val(hoy2);
    $('#enviarcorreo').css("display", "");
}
async function renderform() {

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
        //ToolsFuncBtnLoader($Btn, 1);

        let params = new Object();
        if (($("#subcategoria").val() == 36) && ($("#detalle2").val() == "")) {
            alert("el campo Detalle es obligatorio");

        } else if ($("#estados").val() == "") {
            alert("el campo Estado es obligatorio");
        } else if ($("#ubicacion").val() == "") {
            alert("el campo Ubicación es obligatorio");
        } else {


            params["Usuario"] = $("#UsuarioAgent").val();
            params["FechaSolicitud"] = $("#FechaSolicitud").val();
            params["Canal"] = $("#Canal").val();
            params["Identificacion"] = $("#Identificacion").val();
            params["CasoId"] = $("#CasoId").val();
            params["Nombre"] = $("#Nombre").val();
            params["CargoId"] = $("#CargoId").val();
            params["Celular"] = $("#Celular").val();
            params["CostoId"] = $("#CostoId").val();
            params["CategotyId"] = $("#CategotyId").val();
            params["SubCategoryyId"] = $("#SubCategoryyId").val();
            params["DescriptionId"] = $("#DescriptionId").val();
            params["sedes"] = $("#sedes").val();
            params["asignadoa"] = $("#asignadoa").val();
            params["categoria"] = $("#categoria").val();
            params["subcategoria"] = $("#subcategoria").val();
            params["detalle"] = $("#detalle").val();
            params["detalle2"] = $("#detalle2").val();
            params["escalamiento"] = $("#escalamiento").val();
            params["escaladoa"] = $("#escaladoa").val();
            params["fescalamiento"] = $("#fescalamiento").val();
            params["rescalamiento"] = $("#rescalamiento").val();
            params["soluciones"] = $("#soluciones").val();
            params["estados"] = $("#estados").val();
            params["fsolucion"] = $("#fsolucion").val();
            params["ubicacion"] = $("#ubicacion").val();
            params["clock"] = $("#clock").val();
            params["Email"] = $("#emailempre").val();
            // params["BEN_INST_DIRECCION"] = $("#txt_BEN_INST_DIRECCION").val();
            // params["BEN_INST_DEPARTAMENTO"] = $("#txt_BEN_INST_DEPARTAMENTO").val();


            await $.ajax({
                type: "post",
                url: '/Home/Guardar',
                data: params ? params : null
            })

            alert("Guardado exitoso")
        }

    }
    catch (ex) {
        alert("Ocurrio un error al guardar, COntacte el administrador")

    }
    finally {
        //ToolsFuncBtnLoader($Btn, 1)

    }

}
async function Enviarcorreo($Btn) {
    try {
        //ToolsFuncBtnLoader($Btn, 1);

        let params = new Object();
        if (($("#asuntomail").val() == "")) {
            alert("el campo asunto es obligatorio");

        } else if ($("#Correos").val() == "") {
            alert("el campo correos es obligatorio");
        } else if ($("#bodymail").val() == "") {
            alert("el campo cuerpo del correo es obligatorio");
        } else {


            params["asuntomail"] = $("#asuntomail").val();
            params["Correos"] = $("#Correos").val();
            params["bodymail"] = $("#bodymail").val();            // params["BEN_INST_DIRECCION"] = $("#txt_BEN_INST_DIRECCION").val();
            // params["BEN_INST_DEPARTAMENTO"] = $("#txt_BEN_INST_DEPARTAMENTO").val();


            await $.ajax({
                type: "post",
                url: '/Home/Enviarcorreo',
                data: params ? params : null
            })

            alert("Envio exitoso")
        }

    }
    catch (ex) {
        alert("Ocurrio un error al guardar, COntacte el administrador")

    }
    finally {
        //ToolsFuncBtnLoader($Btn, 1)

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