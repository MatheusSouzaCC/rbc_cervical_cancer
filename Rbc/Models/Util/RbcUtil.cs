using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rbc.Models.Util
{
    public static class RbcUtil
    {

        //calculo da similaridade -> (valor da soma das variaveis/soma dos pesos das variaveis) = score

        public static double ConsultarSimilaridade<TCaso>(TCaso caso) where TCaso : Caso // <- passar os dois casos a serem comparados
        {
            // Chamar aqui -> ConsultarSimilaridadeParaTiposNumericos();
            return 0.0;
        }

        /// <summary>
        /// Consulta similaridade para os tipos numéricos.
        /// </summary>
        /// <param name="v1c1">Valor 1 do caso 1</param>
        /// <param name="v1c2">Valor 1 do caso 2</param>
        /// <returns></returns>
        private static double ConsultarSimilaridadeParaTiposNumericos(int v1c1, int v1c2, int intervaloMin, int intervaloMax)
        {
            return 1 - Math.Abs(v1c2 - v1c1) / (intervaloMax - intervaloMin);
        }

        public static IList<Caso> CalcularSimilaridade(List<Caso> casos)
        {
            foreach (var caso in casos)
            {
                caso.Similaridade = 100;
            }

            return casos.OrderByDescending(c => c.Similaridade).Take(40).ToList();
        }
        /*
         - Ordenar os itens com base no score.
         */
    }
}
