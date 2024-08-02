using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Clases
{
    public class Combate
    {
        public event Action<IJugador, IJugador> RondaIniciada;
        public event Action<IJugador> CombateFinalizado;

        IJugador atacado;
        IJugador atacante;
        static Random random;

        static Combate()
        {
            random = new Random();
        }
        public Combate(IJugador jugador1, IJugador jugador2)
        {
            atacante = SeleccionarPrimerAtacante(jugador1, jugador2);
            atacado = (atacante == jugador1) ? jugador2 : jugador1;
        }

        private static IJugador SeleccionarPrimerAtacante(IJugador jugador1, IJugador jugador2)
        {
            if (jugador1.Nivel != jugador2.Nivel)
            {
                return jugador1.Nivel < jugador2.Nivel ? jugador1 : jugador2;
            }
            else
            {
                return SeleccionarJugadorAleatoriamente(jugador1, jugador2);
            }
        }

        private static IJugador SeleccionarJugadorAleatoriamente(IJugador jugador1, IJugador jugador2)
        {
            return random.Next(2) == 0 ? jugador1 : jugador2;
        }

        public void IniciarRonda()
        {
            RondaIniciada?.Invoke(atacante, atacado);
            int puntosDeAtaque = atacante.Atacar((Personaje)atacado);
            atacado.RecibirAtaque(puntosDeAtaque);
        }

        public IJugador EvaluarGanador()
        {
            if (atacado.PuntosDeVida <= 0)
            {
                return atacante;
            }
            else
            {
                IJugador temp = atacante;
                atacante = atacado;
                atacado = temp;
                return null;
            }
        }

        public void Combatir()
        {
            IJugador ganador;
            do
            {
                IniciarRonda();
                ganador = EvaluarGanador();
            } while (ganador == null);

            CombateFinalizado?.Invoke(ganador);

            ResultadoCombate resultadoCombate = new ResultadoCombate(
            ganador.ToString(),
            (ganador == atacante) ? atacado.ToString() : atacante.ToString(),
            DateTime.Now
        );

            SerializarResultadoCombate(resultadoCombate, "resultado_combate.txt");
        }

        private void SerializarResultadoCombate(ResultadoCombate resultado, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ResultadoCombate));
                    serializer.Serialize(sw, resultado);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar serializar el resultado del combate: {ex.Message}");
            }
        }
    }
}
