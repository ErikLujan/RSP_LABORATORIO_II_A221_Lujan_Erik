using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Guerrero : Personaje
    {
        public Guerrero(int id, string nombre) : base(id, nombre) { }
        public Guerrero(int id, string nombre, short nivel) : base(id, nombre, nivel) { }

        public override void AplicarBeneficiosDeClase()
        {
            puntosDeDefensa = (int)(puntosDeDefensa * 1.1);
        }
    }
}
