window.onload = inicializa;

function inicializa()
{
    CargarSuperheroes()
}


function CargarSuperheroes() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://localhost:44361/Api/SuperheroesApi");

    
    miLlamada.onreadystatechange = function () {
        var table = document.getElementById("tableSuperheroe");//Instanciamos el elemento table de la página html
        var arraySuperheroes = JSON.parse(miLlamada.responseText);//Obtenemos el array de personas (empleados)
        if (miLlamada.readyState == 4 && miLlamada.status == 200)
        {
            for (i = 0; i < arraySuperheroes.length; i++)
            {
                var tr = document.createElement('tr');//Generemos un tag <tr>

                var td = document.createElement('td');//Creamos un tag <td> para el nombre del empleado
                td.innerHTML = "" + arraySuperheroes[i].NombreSuperheroe + "";
                tr.appendChild(td);

                var tdButtons = document.createElement("td");//Agregamos un tag <td> para los botones

                var checkBox = document.createElement("INPUT");
                checkBox.setAttribute("type", "checkbox");
                checkBox.setAttribute("value", arraySuperheroes[i].IdSuperheroe);
                checkBox.setAttribute("id", arraySuperheroes[i].IdSuperheroe);
                checkBox.setAttribute("class", "CHE");


                tdButtons.appendChild(checkBox);

                tr.appendChild(tdButtons);//Le asignamos la variable td al tag <tr> 

                table.appendChild(tr);//Le asignamos la variable tr a la tabla
            }
        }
    };

    miLlamada.send();
}

function VerMisionesPorSuperheroe()
{
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://localhost:44361/Api/MisionesApi");


    miLlamada.onreadystatechange = function ()
    {
        var table = document.getElementById("listadoSuperheroeConMisiones");//Instanciamos el elemento table de la página html
        var arrayMisiones = JSON.parse(miLlamada.responseText);//Obtenemos el array de personas (empleados)
        if (miLlamada.readyState == 4 && miLlamada.status == 200)
        {
            //me falta hacer el boton
        }
    };

    miLlamada.send();
}
