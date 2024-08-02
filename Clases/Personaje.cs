using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public abstract class Personaje : IJugador
    {
        public event Action<Personaje, int> AtaqueLanzado;
        public event Action<Personaje, int> AtaqueRecibido;

        private decimal id;
        private short nivel;
        private string nombre;
        protected int puntosDeDefensa;
        protected int puntosDePoder;
        protected int puntosDeVida;
        private static Random random;
        private string titulo;

        public string Titulo { set { this.titulo = value; } }

        public short Nivel { get { return this.nivel; } }

        public int PuntosDeVida { get { return this.puntosDeVida; } }

        public Personaje()
        {
            random = new Random();
        }
        public Personaje(decimal id, string nombre)
        {
            this.id = id; 
            this.nombre = nombre;
        }
        public Personaje(decimal id, string nombre, short nivel) :this(id, nombre)
        {
            this.nivel = nivel;
        }

        public abstract void AplicarBeneficiosDeClase();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"* ID:{this.id}");
            sb.AppendLine($"* Nivel: {this.nivel}");
            sb.AppendLine($"* Nombre: {this.nombre}");
            sb.AppendLine($"* Puntos de Defensa: {this.puntosDeDefensa}");
            sb.AppendLine($"* Puntos de Poder: {this.puntosDePoder}");
            sb.AppendLine($"* Puntos de Vida: {this.puntosDeVida}");
            sb.AppendLine($"* Titulo: {this.titulo}");

            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            return obj is Personaje otroPj && this.id == otroPj.id;
        }

        public override int GetHashCode()
        {
            return (int)this.id;
        }
        public int Atacar(Personaje objetivo)
        {
            int puntosAtaque = (int)(puntosDePoder * (random.NextDouble() * 0.9 + 0.1));
            AtaqueLanzado?.Invoke(this, puntosAtaque);

            objetivo.RecibirAtaque(puntosAtaque);

            return puntosAtaque;
        }

        public void RecibirAtaque(int puntosDeAtaque)
        {
            int puntosDefensa = (int)(puntosDeDefensa * (random.NextDouble() * 0.9 + 0.1));
            int puntosRecibidos = Math.Max(0, puntosDeAtaque - puntosDefensa);

            puntosDeVida = Math.Max(0, puntosDeVida - puntosRecibidos);
            AtaqueRecibido?.Invoke(this, puntosRecibidos);
        }

        public static bool operator ==(Personaje p1, Personaje p2)
        {
            return (p1.id == p2.id);
        }
        public static bool operator !=(Personaje p1, Personaje p2)
        {
            return !(p1 == p2);
        }
    }
}
