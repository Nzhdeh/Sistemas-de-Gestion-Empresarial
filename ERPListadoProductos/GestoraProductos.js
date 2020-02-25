new Vue({
    el: '#app',
    template: ejemplo,
    data: {
		productos:
		[
            
		]
    },
    methods: 
    {
        cargarListadoProductos: function ()
        {

            var miLlamada = "https://proyectoerp.azurewebsites.net/api/Producto";

            this.$http.get(miLlamada).then(function(reponse){
				this.prductos=reponse;
			})
        }
    }
})