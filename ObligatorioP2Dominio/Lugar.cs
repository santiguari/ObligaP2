using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioP2Dominio
{
    class Lugar
    {
        private int id;
        private string nombre;
        private decimal dimensiones;

        public Lugar(int id, string nombre, decimal dimensiones)
        {
            this.id = id;
            this.nombre = nombre;
            this.dimensiones = dimensiones;
        }

        public int Id
        {
            get { return this.id; }
        }
        public string Nombre
        {
            get { return this.nombre; }
        }
    }
}
