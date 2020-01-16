window.onload = inicializa;

function inicializa() {
    document.getElementById("btnSaludar").addEventListener("click", pedirSaludo);
    document.getElementById("btnPedirApellido").addEventListener("click", pedirApellidos);
    document.getElementById("btnDelete").addEventListener("click", borrar);
}

function pedirSaludo() {
    //alert("hola");

    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "../Paginas/Hola.html");

    //Definicion estados
    miLlamada.onreadystatechange = function () {
        

        if (miLlamada.readyState < 4)
        {

            //alert(miLlamada.readyState);
            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
            document.getElementById("divSaludo").innerHTML = "Cargando...";
        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                //alert(miLlamada.status);

                //var arrayPersonas = JSON.parse(miLlamada.responseText);
                var mensage = miLlamada.responseText;
                //funcionQueHagaAlgoConLasPersonas(mensage);
                document.getElementById("divSaludo").innerHTML += mensage;
            }

    };

    miLlamada.send();

}

function pedirApellidos()
{
    //alert("hola");

    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://crudtoflamaapi.azurewebsites.net/api/Persona");

    //Definicion estados
    miLlamada.onreadystatechange = function () {


        if (miLlamada.readyState < 4) {

            //alert(miLlamada.readyState);
            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
            document.getElementById("divApellido").innerHTML = "Cargando...";
        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                //alert(miLlamada.status);

                //var arrayPersonas = JSON.parse(miLlamada.responseText);
                var mensage = miLlamada.responseText;

                var arrayPersonas = JSON.parse(mensage);

                

                //mensage.charAt().substring(18,40);
                //funcionQueHagaAlgoConLasPersonas(mensage);
                //document.getElementById("divApellido").innerHTML = mensage.substr(2, 20);
                document.getElementById("divApellido").innerHTML = arrayPersonas[0].apellidos;
            }

    };

    miLlamada.send();
}

function borrar() {
    //alert("hola");

    var miLlamada = new XMLHttpRequest();
    var idPersona = document.getElementById("btnDelete").value;

    miLlamada.open("DELETE", "https://crudtoflamaapi.azurewebsites.net/api/Persona/"+idPersona);

    //Definicion estados
    miLlamada.onreadystatechange = function ()
    {
        if (miLlamada.readyState < 4) {

            //alert(miLlamada.readyState);
            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
            document.getElementById("divDelete").innerHTML = "Borrando...";
        }
        else
            if (miLlamada.readyState < 4 && miLlamada.status == 204)
            {
                alert("se ha borrado correctamente");

                //var arrayPersonas = JSON.parse(miLlamada.responseText);
                //var mensage = miLlamada.responseText;
                ////funcionQueHagaAlgoConLasPersonas(mensage);
                //document.getElementById("divSaludo").innerHTML += mensage;
            }

    };

    miLlamada.send();

}