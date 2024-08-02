using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public interface IJugador
    {
        short Nivel { get; }
        int PuntosDeVida { get; }
        int Atacar(Personaje objetivo);
        void RecibirAtaque(int puntosDeAtaque);
    } 
}
