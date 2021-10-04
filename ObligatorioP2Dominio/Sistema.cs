using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioP2Dominio
{
    public class Sistema
    {
        /*Aqui estoy agregando los atributos de tipo listo y a su vez los inicializo para no hacerlo en los metodos luego*/
        private List<Lugar> lugares = new List<Lugar>();
        private List<Actividad> actividades = new List<Actividad>();
        private List<Categoria> categorias = new List<Categoria>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Compra> compras = new List<Compra>();


        public Sistema()
        {
            PrecargaCategorias();
            PrecargaActividades();
            PrecargaLugarAbierto();
            PrecargaLugaresCerrados();

        }

        private void PrecargaCategorias()
        {
            this.AltaCategorias("Torneo", "Evento que implica una competencia entre diferentes partes");
            this.AltaCategorias("Deportivo", "Partidos de diversos deportes");
            this.AltaCategorias("Concierto", "Eventos de tipo musicales de diversos generos");
            this.AltaCategorias("Corporativo", "Evento gastronomico de degustacion");
            this.AltaCategorias("Feria Gastronomica", "Evento gastronomico de degustacion");
        }


        private void PrecargaActividades()   /*Ref 1. Estadio Centenario 2.Teatro de verano 3.Estadio penarol
                                               4.Kibon Avanza 5.Antel Arena 6. Latu*/
        {
            this.altaActividad("Gaming Talent", "Torneo", 6, "C16", 300);
            this.altaActividad("Campeonato sudamericana 2021", "Deportivo", 1, "P", 5000);
            this.altaActividad("Recruiting Open Day", "Corporativo", 4, "C20", 150);
            this.altaActividad("El poder de la actitud", "Corporativo", 4, "C10", 300);
            this.altaActividad("Feria Delicias", "Feria Gastronomica", 6, "P", 500);
            this.altaActividad("Vuelas Palos", "Concierto", 2, "C10", 12000);
            this.altaActividad("Edicion 22 Torneo truco", "Torneo", 4, "C30", 50);
            this.altaActividad("The Wall", "Concierto", 1, "C20", 50000);
            this.altaActividad("Clasico Uruguayo Benefico", "Deportivo", 3, "C20", 1000);
            this.altaActividad("Food Day", "Feria Gastronomica", 2, "P", 900);
        }
        private void PrecargaLugarAbierto()
        {
            this.AltaLugaresAbiertos(1, "Estadio Centenario", 10000);
            this.AltaLugaresAbiertos(2, "Teatro de verano", 3000);
            this.AltaLugaresAbiertos(3, "Estadio Penarol", 9000);
        }

        private void PrecargaLugaresCerrados()
        {
            this.AltaLugaresCerrados(4, "Kibon Avanza", 2000, true, 5000);
            this.AltaLugaresCerrados(5, "Antel Arena", 9000, true, 11000);
            this.AltaLugaresCerrados(6, "Latu", 4500, false, 5000);
        }


        public void AltaCategorias(string nombre, string descripcion)
        {
            if (nombre != "" && descripcion != "" && ExisteCategoria(nombre) == null)
            {
                Categoria unaCategoria = new Categoria(nombre, descripcion);
                categorias.Add(unaCategoria);
            }
        }

        private Categoria ExisteCategoria(string nombre)
        {
            Categoria categoriaBuscada = null;
            int i = 0;
            while (i < categorias.Count && categoriaBuscada == null)
            {
                if (categorias[i].Nombre == nombre)
                {
                    categoriaBuscada = categorias[i];
                }
                i++;
            }
            return categoriaBuscada;

        }


        private void altaActividad(string nombre, string NombreCategoria, int IdLugar,
            string EdadMinina, int cantidadLike)// el atributo de la Clase Abierto no se agrega porque pertenece a la clase 
        {
            //Primero verifico los parametros

            if (nombre != "" && NombreCategoria != "" && IdLugar > 0 && EdadMinina != "" && cantidadLike > 0)
            {
                if (!ExisteActividad(nombre))
                {
                    Categoria miCategoria = ExisteCategoria(NombreCategoria);//creo un variable con el dato nombrecategoria para acceder al metodo existe
                    if (miCategoria != null)
                    { //Verifico que el dato categoria q me pasaron sea categoria y sea false

                        Lugar miLugar = ExisteLugar(IdLugar); //idem categoria
                        if (miLugar != null)
                        {

                            Actividad unaActividad = new Actividad(nombre, miCategoria, miLugar, EdadMinina, cantidadLike);

                            actividades.Add(unaActividad);
                        }//Ahora tengo que ir a armar el metodo constructor a la clase Actividad ->
                    }
                }
            }
        }

        //creo un metodo aparte para verificar que el nombre no existe
        //Lo ideal y que es unico es el ID pero como es static no me permite obtenerlo de la clase
        private bool ExisteActividad(string nombre)
        {
            bool existe = false;
            int i = 0;
            while (i < actividades.Count && !existe)
            {
                if (actividades[i].Nombre.ToUpper() == nombre.ToUpper()) //El .Nombre refiere a la property [get] que esta en la clase Actividad
                {
                    existe = true;
                }
                i++;
            }
            return existe;
        }


        private void AltaLugaresAbiertos(int idLugar, string nombre, decimal dimensiones)
        {
            if (idLugar > 0 && nombre != "" && dimensiones > 0)
            {
                /*Abierto unLugar = ExisteLugar(idLugar);
                if (unLugar!=null && unLugar is Abierto)  
                {*/ //No tiene sentido validar porque no me estan pasando un objeto por parametro

                Abierto unLugarAbierto = new Abierto(idLugar, nombre, dimensiones);
                this.lugares.Add(unLugarAbierto);
            }

        }
        private void AltaLugaresCerrados(int idLugar, string nombre, decimal dimensiones, bool accesibilidad, decimal valorMantenimiento)//Duda si el aforo maximo es estatico
        {
            if (idLugar > 0 && nombre != "" && dimensiones > 0 && valorMantenimiento > 0)
            {
                if (ExisteLugar(idLugar) == null)
                {
                    Cerrado unLugarCerrado = new Cerrado(idLugar, nombre, dimensiones, accesibilidad, valorMantenimiento);
                    this.lugares.Add(unLugarCerrado);
                }
            }
        }

        private Lugar ExisteLugar(int id)
        {
            Lugar lugarBuscado = null;
            int i = 0;

            while (i < lugares.Count && lugarBuscado == null)
            {
                if (lugares[i].Id == id)
                {
                    lugarBuscado = lugares[i];
                }
                i++;
            }
            return lugarBuscado;
        }

        public string MostrarActividades()
        {
            string miActividad = "";
            for (int i = 0; i < actividades.Count; i++)
            {
                miActividad += actividades[i] + "\n";
            }
            return miActividad;
        }

        public string MostrarActividadesTodoPublico()
        {
            string miActividadTP = "";
            for (int i = 0; i < this.actividades.Count; i++)
            {
                if (actividades[i].EdadMinima == "P")
                {
                    miActividadTP += actividades[i] + "\n";
                }
            }
            return miActividadTP;
        }
        //eso de la ubicacion que dijiste puede ser, Gravedad	Código	Descripción	Proyecto	Archivo	Línea	Estado suprimido
        //Obligatorio2021.dll este archivo tiene que estar en la carpeta netcoreapp3.1 de la carpeta del proyecto
        // 'C:\Users\guill\OneDrive\Escritorio\Programación 2\Obligatorio2021\ObligatorioDominio\bin\Debug\netcoreapp3.1\Obligatorio2021.dll'			1	

        public string CambiarAforoMaximo(int NuevoValorAforoMaximo)
        {
            string nuevoAforo = "";
            if (NuevoValorAforoMaximo > 0 && Cerrado.AforoMaximo != NuevoValorAforoMaximo)
            {
                Cerrado.AforoMaximo = NuevoValorAforoMaximo;
                nuevoAforo = "El nuevo aforo maximo para el lugar cerrado es" + Cerrado.AforoMaximo;
            }
            return nuevoAforo;

        }
        public string CambiarPrecioButaca(decimal NuevoPrecioButaca)
        {
            string NuevoPrecio = "";
            if (NuevoPrecioButaca > 0 && Abierto.PrecioButaca != NuevoPrecioButaca)
            {
                Abierto.PrecioButaca = NuevoPrecioButaca;
                NuevoPrecio = "El nuevo precio de la butaca se ha cambiado con exito y ahora es " + Abierto.PrecioButaca;
            }
            return NuevoPrecio;
        }

        public string ListarActividadesDeCategoria(string nombreCategoria, DateTime FechaInicio, DateTime FechaFin)
        {
            string ListaActividades = "";
            FechaFin = FechaFin.AddDays(1);

            foreach (Categoria MiCategoria in categorias)
                if (MiCategoria.Nombre == nombreCategoria)
                {

                    if (ExisteCategoria(nombreCategoria) != null)
                    {
                        for (int i = 0; i < actividades.Count; i++)
                        {

                            if (actividades[i].Fecha >= FechaInicio && actividades[i].Fecha <= FechaFin)
                            {
                                ListaActividades += actividades[i] + "/n";
                            }
                        }

                    }
                }
            return ListaActividades;

        }

    }
}
