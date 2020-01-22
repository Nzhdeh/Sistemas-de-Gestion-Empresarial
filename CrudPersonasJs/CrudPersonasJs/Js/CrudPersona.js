window.onload = inicializa;

function inicializa()
{
    document.getElementById("añadir").addEventListener("click", introducirPersona);
    document.getElementById("editar").addEventListener("click", clickarEditar);

    ListadoPersonasConDepartamento();

    var añadir = document.getElementById("addEmployeeModal");;
    var editar = document.getElementById("editEmployeeModal");;
    var eliminar = document.getElementById("deleteEmployeeModal");;
}

function ListadoPersonasConDepartamento() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://crudtoflamaapi.azurewebsites.net/api/Departamento");

    //Definición del estado
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayDepartamentos = JSON.parse(miLlamada.responseText);
            cargarPersonas(arrayDepartamentos);
        }
    };

    miLlamada.send();
}

function clickarEditar(id) {
    var guardar = document.getElementById("guardarE");
    var persona = new Object();
    persona = buscarPersonaPorID(id);
    //document.getElementById("idE").value = persona.id;
    document.getElementById("nombreE").value = persona.nombre;
    document.getElementById("apellidosE").value = persona.apellidos;
    document.getElementById("fechaE").value = persona.fechaNacimiento;
    (persona.direccion == "" ? "" : document.getElementById("direccionE").value = persona.direccion);
    (persona.telefono == "" ? "" : document.getElementById("telefonoE").value = persona.telefono);
    (persona.foto == "" ? "" : document.getElementById("fotoE").value = persona.foto);
    document.getElementById("editSelect").value = persona.idDepartamento;

    guardar.onclick = function () {
        var nuevaPersona = new Object();
        nuevaPersona.id = id;
        nuevaPersona.nombre = document.getElementById("nombreE").value;
        nuevaPersona.apellidos = document.getElementById("apellidosE").value;
        nuevaPersona.fechaNacimiento = document.getElementById("fechaE").value;
        nuevaPersona.direccion = document.getElementById("direccionE").value;
        nuevaPersona.telefono = document.getElementById("telefonoE").value;
        nuevaPersona.foto = document.getElementById("fotoE").value;
        nuevaPersona.idDepartamento = document.getElementById("editSelect").value;

        var editarLlamada = new XMLHttpRequest();
        editarLlamada.open("PUT", "https://crudtoflamaapi.azurewebsites.net/api/Persona/" + id, false);
        editarLlamada.setRequestHeader('Content-type', 'application/json');

        var json = JSON.stringify(nuevaPersona);

        //Definicion estados
        editarLlamada.onreadystatechange = function () {

            if (editarLlamada.readyState < 4) {


            }
            else
                if (editarLlamada.readyState == 4 && editarLlamada.status == 204) {

                    alert("Persona actualizada con exito");
                    editar.style.display = "none";

                }
        };

        editarLlamada.send(json);

    }

    editar.style.display = "block";

}

//function pedirApellidos() {
//    //alert("hola");

//    var miLlamada = new XMLHttpRequest();
//    miLlamada.open("GET", "https://crudtoflamaapi.azurewebsites.net/api/Persona");

//    //Definicion estados
//    miLlamada.onreadystatechange = function () {


//        if (miLlamada.readyState < 4) {

//            //alert(miLlamada.readyState);
//            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
//            document.getElementById("divApellido").innerHTML = "Cargando...";
//        }
//        else
//            if (miLlamada.readyState == 4 && miLlamada.status == 200) {
//                //alert(miLlamada.status);

//                //var arrayPersonas = JSON.parse(miLlamada.responseText);
//                var mensage = miLlamada.responseText;

//                var arrayPersonas = JSON.parse(mensage);



//                //mensage.charAt().substring(18,40);
//                //funcionQueHagaAlgoConLasPersonas(mensage);
//                //document.getElementById("divApellido").innerHTML = mensage.substr(2, 20);
//                document.getElementById("divApellido").innerHTML = arrayPersonas[0].apellidos;
//            }

//    };

//    miLlamada.send();
//}