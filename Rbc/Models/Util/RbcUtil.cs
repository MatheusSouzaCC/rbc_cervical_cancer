using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rbc.Models.Util
{
    public static class RbcUtil
    {

        //calculo da similaridade -> (valor da soma das variaveis/soma dos pesos das variaveis) = score

        public static IList<Caso> CompararSimilaridade(Caso caso, IList<Caso> casosDaBase)
        {
            foreach (var casoDaBase in casosDaBase)
            {
                casoDaBase.Similaridade = ObterSimilaridade(caso, casoDaBase);
            }

            return casosDaBase.OrderBy(x => x.Similaridade).ToList();
        }

        public static double ObterSimilaridade(Caso caso1, Caso caso2)
        {
            Type tipo = typeof(Caso);
            var atributos = tipo.GetProperties();
            double similaridadeTotal = 0;
            int somaDosPesos = 0;

            foreach (var atributo in atributos)
            {
                var atributoDeSimilaridade = Similaridade.GetAtributoDeSimilaridade(atributo);
                double similaridade = 0;

                var v1c1 = atributo.GetValue(caso1);
                var v1c2 = atributo.GetValue(caso1);

                if (atributo.PropertyType == typeof(int))
                    similaridade = ConsultarSimilaridadeParaTiposInteiros((int)v1c1, (int)v1c2, 0, 100);

                if (atributo.PropertyType == typeof(double))
                    similaridade = ConsultarSimilaridadeParaTiposDecimais((double)v1c1, (double)v1c2, 0, 100);

                if (atributo.PropertyType == typeof(bool))
                    similaridade = ConsultarSimilaridadeParaTiposBooleanos((bool)v1c1, (bool)v1c2);

                somaDosPesos += atributoDeSimilaridade.peso;
                similaridadeTotal += atributoDeSimilaridade.peso * similaridade;

                //similaridade.peso 
            }

            return similaridadeTotal / somaDosPesos;
        }

        /// <param name="v1c1">Valor 1 do caso 1</param>
        /// <param name="v1c2">Valor 1 do caso 2</param>
        /// <returns></returns>
        private static double ConsultarSimilaridadeParaTiposInteiros(int v1c1, int v1c2, int intervaloMin, int intervaloMax)
        {
            return 1 - Math.Abs(v1c2 - v1c1) / (intervaloMax - intervaloMin);
        }

        /// <param name="v1c1">Valor 1 do caso 1</param>
        /// <param name="v1c2">Valor 1 do caso 2</param>
        /// <returns></returns>
        private static double ConsultarSimilaridadeParaTiposDecimais(double v1c1, double v1c2, double intervaloMin, double intervaloMax)
        {
            return 1 - Math.Abs(v1c2 - v1c1) / (intervaloMax - intervaloMin);
        }

        /// <param name="v1c1">Valor 1 do caso 1</param>
        /// <param name="v1c2">Valor 1 do caso 2</param>
        /// <returns></returns>
        private static double ConsultarSimilaridadeParaTiposBooleanos(bool v1c1, bool v1c2)
        {
            return v1c1 == v1c2 ? 1 : 0;
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
