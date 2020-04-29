window.onload = inicializa;

var arrayCiudades = null;//compadrismo

function inicializa()
{
    CargarCiudades();
}

/**
 * esto lo he hecho para que sea mas facil a la hora de llamar a los metodos CargarCiudades() y FiltrarCiudad(nombre)
 * @param {any} nombre
 */
function Cargar(nombre) 
{
    if (nombre == "")
    {
        CargarCiudades();
    } else
    {
        FiltrarCiudad(nombre);
    }
}

/**
 *sirve para obtener las ciudades y rellenar la tabla correspondoinete 
 */
function CargarCiudades()
{
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://webapiaemet.azurewebsites.net/api/ciudades",true);//true porque es asincrono


    miLlamada.onreadystatechange = function ()
    {
        if (miLlamada.readyState == 4 && miLlamada.status == 200)
        {
            var table = document.getElementById("tableCiudades");//Instanciamos el elemento table de la página html

            var cantidadElementosTabla = table.childElementCount;
            if (cantidadElementosTabla > 0)
            {
                for (var i = 0; i < cantidadElementosTabla; i++)
                {
                    BorrarFilaTabla("tableCiudades");
                }
            }
            
            arrayCiudades = JSON.parse(miLlamada.responseText);//Obtenemos el array 

            for (i = 0; i < arrayCiudades.length; i++)
            {
                var tr = document.createElement('tr');//Generemos un tag <tr>

                //var tdId = document.createElement('td');//Creamos un tag <td> para el id
                var tdNombre = document.createElement('td');//Creamos un tag <td> para el nombre de la ciudad

                //tdId.innerHTML = arrayCiudades[i].idCiudad;
                tdNombre.innerHTML = arrayCiudades[i].nombreCiudad;

                //tr.appendChild(tdId);
                tr.appendChild(tdNombre);

                table.appendChild(tr);//Le asignamos la variable tr a la tabla
            }
        }
    };
    miLlamada.send();
}

/**
 *sirve para obtener los pronosticos de una ciudad y rellenar la tabla correspondoinete
 */
function CargarPronosticos(idCiudad)
{
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://webapiaemet.azurewebsites.net/api/prediccion/" + idCiudad, true);//true porque es asincrono

    miLlamada.onreadystatechange = function ()
    {
        if (miLlamada.readyState == 4 && miLlamada.status == 200)
        {
                
            var arrayPredicciones = JSON.parse(miLlamada.responseText); //Obtenemos el array 
            var table = document.getElementById("tablePronosticos");//Instanciamos el elemento table de la página html

            var cantidadElementosTabla = table.childElementCount;

            if (cantidadElementosTabla > 0)
            {
                for (var i = 0; i < cantidadElementosTabla; i++)
                {
                    BorrarFilaTabla("tablePronosticos");
                }
            }

            for (i = 0; i < arrayPredicciones.length; i++) {
                var tr = document.createElement('tr');//Generemos un tag <tr>

                var tdPro = document.createElement('td');//Creamos un tag <td> para el nombre de la ciudad
                var tdMax = document.createElement('td');
                var tdMin = document.createElement('td');
                var tdHumedad = document.createElement('td');

                tdPro.innerHTML = arrayPredicciones[i].pronostico;
                tdMax.innerHTML = arrayPredicciones[i].temperaturaMaxima;
                tdMin.innerHTML = arrayPredicciones[i].temperaturaMinima;
                tdHumedad.innerHTML = arrayPredicciones[i].humedad;

                tr.appendChild(tdPro);
                tr.appendChild(tdMax);
                tr.appendChild(tdMin);
                tr.appendChild(tdHumedad);

                table.appendChild(tr);//Le asignamos la variable tr a la tabla
            }
        }
    };
    miLlamada.send();
}

/**
 *sirve para filtrar las ciudades
 */
function FiltrarCiudad(ciudadIngresado)
{
    //var miLlamada = new XMLHttpRequest();
    //miLlamada.open("GET", "https://webapiaemet.azurewebsites.net/api/ciudades", true);//true porque es asincrono


    //miLlamada.onreadystatechange = function ()
    //{
    //    if (miLlamada.readyState == 4 && miLlamada.status == 200)
    //    {
            if (arrayCiudades != null)
            {
                var table = document.getElementById("tableCiudades");//Instanciamos el elemento table de la página html

                var cantidadElementosTabla = table.childElementCount;

                if(cantidadElementosTabla > 0)
                {
                    for (var i = 0; i < cantidadElementosTabla; i++)
                    {
                        BorrarFilaTabla("tableCiudades");
                    }
                }

                //lo repito porque el bucle anterior no borra el ultimo elemento
                cantidadElementosTabla = table.childElementCount;
                if (cantidadElementosTabla > 0)
                {
                    for (var i = 0; i < cantidadElementosTabla; i++)
                    {
                        BorrarFilaTabla("tableCiudades");
                    }
                }

                //var arrayCiudades = JSON.parse(miLlamada.responseText);//Obtenemos el array 

                var arrayAux = EncontrarCiudad(arrayCiudades, ciudadIngresado);

                for (i = 0; i < arrayAux.length; i++)
                {
                    var tr = document.createElement('tr');//Generemos un tag <tr>

                    //var tdId = document.createElement('td');//Creamos un tag <td> para el id
                    var tdNombre = document.createElement('td');//Creamos un tag <td> para el nombre de la ciudad

                    //tdId.innerHTML = arrayAux[i].idCiudad;
                    tdNombre.innerHTML = arrayAux[i].nombreCiudad;

                    //tr.appendChild(tdId);
                    tr.appendChild(tdNombre);

                    table.appendChild(tr);//Le asignamos la variable tr a la tabla
                }

            }
            
    //    }
    //};
    //miLlamada.send();
}

/**
 * sirve para borrar la primera fila de la tabla
 * @param {any} nombreTabla
 */
function BorrarFilaTabla(nombreTabla)
{
    var list = document.getElementById(nombreTabla);
    list.removeChild(list.childNodes[0]);
}

/**
 * sirve para devolver el id de la ciudad pulsada
 */
function ObtenerIdCiudad()
{
    if (arrayCiudades != null)
    {
        var table = document.getElementById('tableCiudades');
        var cells = table.getElementsByTagName('td');
        var id;

        for (var i = 0; i < cells.length; i++) {
            // Take each cell
            var cell = cells[i];
            // do something on onclick event for cell
            cell.onclick = function ()
            {
                //codigo de internet
                // Get the row id where the cell exists
                var rowId = this.parentNode.rowIndex-1;//le he puesto -1 para que coja la misma linea en la que pulso

                var rowsNotSelected = table.getElementsByTagName('tr');
                for (var row = 0; row < rowsNotSelected.length; row++)
                {
                    rowsNotSelected[row].style.backgroundColor = "";
                    rowsNotSelected[row].classList.remove('selected');
                }

                var rowSelected = table.getElementsByTagName('tr')[rowId];
                rowSelected.style.backgroundColor = "red";
                rowSelected.className += "selected";

                msg = this.innerHTML;

                myFunction(msg);//para poner el nombre de la ciudad en grande
            }
        }

    
        for (i = 0; i < arrayCiudades.length; i++) {
            if (arrayCiudades[i].nombreCiudad == msg)
                id = arrayCiudades[i].idCiudad;
        }
    }
    
    return id;
}

/**
 * sirve para sacar el nombre de la ciudad
 */
function ObtenerNombreCiudadPulsado()
{
    var table = document.getElementById('tableCiudades');
    var cells = table.getElementsByTagName('td');

    for (var i = 0; i < cells.length; i++) {
        // Take each cell
        var cell = cells[i];
        // do something on onclick event for cell
        cell.onclick = function ()
        {            
            msg = this.innerHTML;
        }
    }
    return msg;
}

/**
 * sirve para encontrar las ciudades que contienen el texto ingresado en el buscador
 * @param {any} arrayCiudades
 * @param {any} ciudadIngresado
 */
function EncontrarCiudad(arrayCiudades, ciudadIngresado)
{

    var array = [];

    for (var i in arrayCiudades)
    {
        if (arrayCiudades[i].nombreCiudad.toLowerCase().includes(ciudadIngresado.toLowerCase()))
        {
            array.push(arrayCiudades[i]);
        }
    }

    return array;
}