using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ResultadoCombate
    {
        string nombreGanador;
        string nombrePerdedor;
        DateTime fechaHora;

        public string NombreGanador { get => this.nombreGanador; set => this.nombreGanador = value; }
        public string NombrePerdedor { get => this.nombrePerdedor; set => this.nombrePerdedor = value; }
        public DateTime FechaHora { get => this.fechaHora; set => this.fechaHora = value; }

        public ResultadoCombate(string nombreGanador, string nombrePerdedor, DateTime fechaHora)
        {
            this.nombreGanador = nombreGanador;
            this.nombrePerdedor = nombrePerdedor;
            this.fechaHora = fechaHora;
        }
    }
}
