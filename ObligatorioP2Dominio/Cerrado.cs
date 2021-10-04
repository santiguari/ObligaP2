using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioP2Dominio
{

    class Cerrado : Lugar
    {
        private bool accesibilidadATotal;
        private decimal valorMantenimiento;
        private static int aforoMaximo; //Es estatico porque se sobrescriben los valores segun letra

        public Cerrado(int id, string nombre, decimal dimensiones, bool accesibilidad, decimal valorMantenimiento) : base(id, nombre, dimensiones)
        {
            this.accesibilidadATotal = accesibilidad;
            this.valorMantenimiento = valorMantenimiento;

        }

        public static int AforoMaximo
        {
            set { Cerrado.aforoMaximo = value; }
            get { return Cerrado.aforoMaximo; }
        }
    }
}
