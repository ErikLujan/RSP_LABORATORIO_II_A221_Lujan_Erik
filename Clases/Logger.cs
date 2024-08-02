using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Logger
    {
        string ruta;

        public Logger(string ruta)
        {
            this.ruta = ruta;
        }

        public void GuardarLog(string texto)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(ruta, true))
                {
                    sw.WriteLine(texto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el log: {ex.Message}");
            }
        }
    }
}
