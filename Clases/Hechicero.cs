using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Hechicero : Personaje
    {
        public Hechicero(int id, string nombre) : base(id, nombre) { }
        public Hechicero(int id, string nombre, short nivel) : base(id, nombre, nivel) { }

        public override void AplicarBeneficiosDeClase()
        {
            puntosDePoder = (int)(puntosDePoder * 1.1);
        }
    }
}
