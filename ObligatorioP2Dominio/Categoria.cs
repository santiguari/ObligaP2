using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioP2Dominio
{
    class Categoria
    {
        private string nombre;
        private string descripcion;

        public string Nombre // property
        {
            get { return this.nombre; }
        }
        //Metodo constructor
        public Categoria(string nombre, string descripcion)
        {

            this.nombre = nombre;
            this.descripcion = descripcion;
        }

    }
}
