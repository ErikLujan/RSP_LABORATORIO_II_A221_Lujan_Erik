using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Aleatorio
    {
        private static Random random;

        public static LadosMoneda TirarUnaMoneda()
        {
            random = new Random();
            int valor = random.Next(1, 3);
            return (LadosMoneda)valor;
        }
    }
}
