const app = new Vue({
    el: '#app',
    template: ejemplo,
    data: {
		productos:
		[
		
		],
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

            var miLlamada = "https://proyectoerp.azurewebsites.net/api/Producto"

            this.$http.get(miLlamada).then(function(reponse){
				this.prductos=reponse
			})
        }
    }
})