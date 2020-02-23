const app = new Vue({
    el: '#app',
    template: ejemplo,
    data: {
        cursos: [
            { name: "Fundamentos de React", url: 'http://cursos.carlosazaustre.es/p/react-js' },
            { name: "Redux con React", url: 'http://cursos.carlosazaustre.es/p/curso-profesional-de-redux-y-react' },
            { name: "React Native", url: 'http://cursos.carlosazaustre.es/p/react-native' },
        ],
        mostrar: true,
        mensaje: "Hola Vue!",
        imagen: "http://laravelacademy.org/wp-content/uploads/2016/08/00-featured-vuejs-logo-simple-256x128.jpg"
    },
    methods: {
        togleMostrar: function ()
        {
            this.mostrar = !this.mostrar
        },
        cargarListadoProductos: function ()
        {

            var miLlamada = new XMLHttpRequest();
            miLlamada.open("GET", "https://localhost:44361/Api/SuperheroesApi");

            miLlamada.onreadystatechange = function ()
            {
                var table = document.getElementById("tableListadoPedoidos");//Instanciamos el elemento table de la página html
                var arraySuperheroes = JSON.parse(miLlamada.responseText);//Obtenemos el array de productos
                if (miLlamada.readyState == 4 && miLlamada.status == 200) {
                    for (i = 0; i < arraySuperheroes.length; i++) {
                        var tr = document.createElement('tr');//Generemos un tag <tr>

                        table.appendChild(tr);//Le asignamos la variable tr a la tabla
                    }
                }
            };

            miLlamada.send();
        }
    }
})