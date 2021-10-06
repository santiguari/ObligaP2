using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioP2Dominio
{

    class Actividad
    {
        private static int id;
        private static int ultimoId;
        private string nombre;
        private Categoria categoria;
        private DateTime fechaHora;
        private Lugar lugar;
        private string edadMinima;
        private static decimal precioBase;
        private int cantidadLike;

        public string Nombre //Property

        {
            get { return this.nombre; }
        }

        public string EdadMinima //Property Edad Minima

        {
            get { return this.edadMinima; }
        }

        public Categoria Categoria //Property

        {
            get { return this.categoria; }
        }

        public DateTime Fecha //Property Edad Minima

        {
            get { return this.fechaHora; }
        }

        //Metodo constructor
        public Actividad(string nombre, Categoria categoria, Lugar lugar, string edadMinima, int cantidadLike)
        {

            this.nombre = nombre;
            this.categoria = categoria;
            this.fechaHora = DateTime.Now;
            this.lugar = lugar;
            this.edadMinima = edadMinima;
            this.cantidadLike = cantidadLike;
        }

        public override string ToString()
        {
            return "\n" + "Actividad: " + this.nombre + "\n" + "Fecha y hora: " + this.fechaHora + "\n" + "Lugar: " + this.lugar + "\n" + "Edad mininma: " + this.edadMinima + "\n" + "Cantidad de likes: " + this.cantidadLike + "\n" + "Categoria: " + this.categoria;
        }

    }
}
