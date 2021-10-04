using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioP2Dominio
{
    class Abierto : Lugar
    {
        private static decimal precioButaca;

        public Abierto(int id, string nombre, decimal dimensiones) : base(id, nombre, dimensiones)
        {
            /*Tengo duda si crear el metodo constructor ya que 
            el atributo es de clase*/
        }
        public static decimal PrecioButaca
        {
            set { Abierto.precioButaca = value; }
            get { return Abierto.precioButaca; }
        }
    }
}
