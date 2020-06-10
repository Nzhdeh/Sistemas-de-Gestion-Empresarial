window.onload = inicializa;

var arrayPalabras = [];//compadrismo
var idUltimaPruebaParaGuardar = 0;//compadrismo
var arrayIdsUltimasPalabras = [];//compadrismo

function inicializa()
{
    //obtenerUltimoIdPrueba();
    //GuardarPrueba();
    //obtenerIdsDeUltimasNPalabras(1);//no funciona
    //var pruebaPal = new ClsPruebaPalabras(65, 182);
    //GuardarPruebaPalabras(pruebaPal);
}

/**
 *sirve para obtener insertar la palabra y la dificultad en la tabla
 */
function InsertarPalabraEnLaLista(palabra, dificultad)
{
    if (palabra != "" && dificultad != 0)
    {
        var table = document.getElementById("tablePalabras");//Instanciamos el elemento table de la página html
        var pal = new ClsPalabras(palabra, dificultad);

        var tr = document.createElement('tr');

        var tdPalabra = document.createElement('td');
        tdPalabra.innerHTML = pal.toString();

        tr.appendChild(tdPalabra);
        table.appendChild(tr);

        arrayPalabras.push(pal);//guardao también en un array ,para poder guardarlo luego en la bbdd
        actualizarTiempoMaximo(dificultad);

        document.getElementById("palabra").value = '';//vacio el input de la palabra
        document.getElementById("dificultad").value = '0';//vacio el select de la dificultad
    } else
    {
        alert("Hay que insertar la palabra y elegir su dificultad");
    }    
}

/**
 * sirve para guardar la prueba y las  palabras en la bbdd 
 */
function GuardarPruebaYPalabras()
{
    if (arrayPalabras.length > 4)
    {
        var tiempo = document.getElementById('tiempoMaximo').innerHTML;
        var cantidadPalabras = arrayPalabras.length;
        var prueba = new ClsPrueba();
        prueba.numeroPalabras = cantidadPalabras;
        prueba.tiempoMaximo = tiempo;
        GuardarPrueba(prueba);

        obtenerUltimoIdPrueba();
            
        if (idUltimaPruebaParaGuardar > 0)
        {
            GuardarPalabras();
            obtenerIdsDeUltimasNPalabras(arrayPalabras.length);

            if (arrayIdsUltimasPalabras.length > 0)
            {
                for (var i = 0; i < arrayIdsUltimasPalabras.length; i++)
                {
                    var pruebaPalabra = new ClsPruebaPalabras();
                    pruebaPalabra.idPalabra = arrayIdsUltimasPalabras[i];
                    pruebaPalabra.idPrueba = idUltimaPruebaParaGuardar;
                    GuardarPruebaPalabras(pruebaPalabra);
                }
                TiempoPorDefecto();
                BorrarFilaTabla();
                arrayPalabras = [];
                alert("Registrado correctamente");
            }
            else
            {
                alert("Hubo algún problema, inténtalo más tarde");
            }
        }
        else
        {
            alert("Hubo algún problema, inténtalo más tarde");             
        }
    }
    else
    {
        alert("Tiene que haber al menos 5 palabras en la tabla");
    }    
}

/**
 * sirve para borrar la primera fila de la tabla
 */
function BorrarFilaTabla()
{
    var table = document.getElementById("tablePalabras");
    var cantidadElementosTabla = table.childElementCount;
    for (var i = 0; i < cantidadElementosTabla; i++)
    {
        table.removeChild(table.childNodes[0]);
    }    
}

/**
 * sirve para poner el tiempo a cero
 */
function TiempoPorDefecto()
{
    var tiempo = document.getElementById('tiempoMaximo').innerHTML;
    tiempo = "00:00:00";
    document.getElementById("tiempoMaximo").innerHTML = tiempo;
}

/**
 * sirve para guardar la prueba
 * */
function GuardarPrueba(prueba)
{
    var mensage;
    
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("POST", "https://localhost:44397/Api/PruebaApi/prueba", false);
    miLlamada.setRequestHeader("Content-type", "application/json");

    miLlamada.onreadystatechange = function ()
    {
        if (miLlamada.readyState == 4 && miLlamada.status == 200)
        {
            mensage = this.responseText;
        }
        else
        {
            mensage = this.responseText;
            alert(mensage);
        }
    };

    var data = JSON.stringify({ "numeroPalabras": prueba.numeroPalabras, "tiempoMaximo": prueba.tiempoMaximo });
    miLlamada.send(data);
    
}

/**
 * sirve para guardar las palabras
 * */
function GuardarPalabras()
{
    var mensage;
    if (arrayPalabras.length > 4)
    {
        for (var i = 0; i < arrayPalabras.length; i++)
        {
            var miLlamada = new XMLHttpRequest();
            miLlamada.open("POST", "https://localhost:44397/Api/PalabraApi/palabra", false);
            miLlamada.setRequestHeader("Content-type", "application/json");

            miLlamada.onreadystatechange = function () {
                if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                    mensage = this.responseText;
                }
                else {
                    mensage = this.responseText;
                    alert(mensage);
                }
            };

            var data = JSON.stringify({ "palabra": arrayPalabras[i].palabra, "dificultad": arrayPalabras[i].dificultad });
            miLlamada.send(data);
        }
    }
}

/**
 * sirve para guardar en la tabla intermedia CJ_PruebasPalabras
 * */
function GuardarPruebaPalabras(pruebaPalabra)
{
    var mensage;
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("POST", "https://localhost:44397/Api/PruebaPalabraApi/pruebaPalabra", false);
    miLlamada.setRequestHeader("Content-type", "application/json");

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            mensage = this.responseText;
        }
        else {
            mensage = this.responseText;
            alert(mensage);
        }
    };

    var data = JSON.stringify({ "idPrueba": pruebaPalabra.idPrueba, "idPalabra": pruebaPalabra.idPalabra });
    miLlamada.send(data);
}

/**
 * sireve para actualizar el tiempo
 * */
function actualizarTiempoMaximo(dificultad)
{
    var total = 0;
    dificultad = parseInt(dificultad); // Convertir el valor a un entero (número).

    tiempo = document.getElementById('tiempoMaximo').innerHTML;
    var minutos = parseInt(tiempo.substring(3, 5));
    var segundos = parseInt(tiempo.substring(6, 8));
    // Aquí valido si hay un valor previo, si no hay datos, le pongo un cero "0".
    minutos = (minutos == null || minutos == undefined || minutos == "") ? 0 : minutos;
    segundos = (segundos == null || segundos == undefined || segundos == "") ? 0 : segundos;

    segundos = (parseInt(segundos) + parseInt(dificultad));
    if (segundos > 59)
    {
        minutos = (parseInt(minutos) + 1);
        segundos = (parseInt(segundos) - 60);
    }
    
    if (minutos < 10 && segundos < 10)
    {
        tiempo = "00:0"+minutos+":0"+segundos;
    }
    else if (minutos < 10 && segundos >= 10)
    {
        tiempo = "00:0" + minutos + ":" + segundos;
    }
    else if (minutos >= 10 && segundos < 10)
    {
        tiempo = "00:" + minutos + ":0" + segundos;
    }
    else if (minutos >= 10 && segundos >= 10)
    {
        tiempo = "00:" + minutos + ":" + segundos;
    }
    
    // Coloco el resultado de la suma
    document.getElementById("tiempoMaximo").innerHTML = tiempo;
}

/**
 * obteiene el id de la última prueba
 * */
function obtenerUltimoIdPrueba()
{
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://localhost:44397/Api/PruebaApi", false);
    var idPrueba=0;
    var mensage;
    miLlamada.onreadystatechange = function ()
    {
        if (miLlamada.readyState == 4 && miLlamada.status == 200)
        {
            idUltimaPruebaParaGuardar = JSON.parse(miLlamada.responseText);//Obtenemos el último id
        } else
        {
            mensage = this.responseText;
            alert(mensage);
        }
    };
    
    miLlamada.send();
}

/**
 * obtiene los ids de las últimas n palabras
 * @param {any} n
 */
function obtenerIdsDeUltimasNPalabras(numero)
{
    var miLlamada = new XMLHttpRequest();
    var uri = "https://localhost:44397/Api/PalabraApi?numero="+numero;
    miLlamada.open("GET", uri, false);
    var mensage;

    miLlamada.onreadystatechange = function ()
    {
        if (miLlamada.readyState == 4 && miLlamada.status == 200)
        {
            arrayIdsUltimasPalabras = JSON.parse(miLlamada.responseText);//Obtenemos el último id
        }
        else
        {
            mensage = this.responseText;
            alert(mensage);
        }
    };
    
    miLlamada.send();
}

class ClsPalabras
{
    constructor(palabra, dificultad)
    {
        this.palabra = palabra;
        this.dificultad = dificultad;
    }

    get getPalabra()
    {
        return this.palabra;
    }

    get getDificultad()
    {
        return this.dificultad;
    }

    set setPalabra(palabra)
    {
        this.palabra = palabra;
    }

    set setDificultad(dificultad)
    {
        this.dificultad = dificultad;
    }

    toString()
    {
        return this.getPalabra + " " + this.getDificultad;
    }
}

class ClsPrueba
{
    constructor(numeroPalabras, tiempoMaximo)
    {
        this.numeroPalabras = numeroPalabras;
        this.tiempoMaximo = tiempoMaximo;
    }

    get getNumeroPalabras() {
        return this.palabra;
    }

    get getTiempoMaximo() {
        return this.dificultad;
    }

    set setNumeroPalabras(numeroPalabras) {
        this.numeroPalabras = numeroPalabras;
    }

    set setTiempoMaximo(tiempoMaximo) {
        this.tiempoMaximo = tiempoMaximo;
    }

    toString() {
        return this.getNumeroPalabras + " " + this.getTiempoMaximo;
    }
}

class ClsPruebaPalabras
{
    constructor(idPrueba, idPalabra)
    {
        this.idPalabra = idPalabra;
        this.idPrueba = idPrueba;
    }

    get getIdPalabra() {
        return this.palabra;
    }

    set setIdPalabra(idPalabra) {
        this.idPalabra = idPalabra;
    }

    get getIdPrueba() {
        return this.dificultad;
    }

    set setIdPrueba(idPrueba) {
        this.idPrueba = idPrueba;
    }
    

    toString() {
        return this.getIdPalabra() + " " + this.getIdPrueba();
    }
}