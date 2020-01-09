window.onload = inicializar;//aqui no hay que poner los parentesis,
                            //porque esto es para lo que quiero que haga cunado se cargue la ventana

//funcion que inicializa los elementos de la pagina
function inicializar() {
    //alert("Hola mundo");
    //añadir evento click al boton Pulsar y que llame al evento
    //cambiarTexto();

    document.getElementById("btnPulsar").addEventListener("click", cambiarTexto, false);
}

//cambia el texto del div divTexto
function cambiarTexto()
{
    //alert("Hola mundo");
    document.getElementById("divTexto").innerHTML = "Hola mundo";
}