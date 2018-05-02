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
                casoDaBase.Similaridade = 100 * ObterSimilaridade(caso, casoDaBase);
            }

            return casosDaBase.OrderByDescending(x => x.Similaridade).Take(40).ToList();
        }

        private static double ObterSimilaridade(Caso caso1, Caso caso2)
        {
            Type tipo = typeof(Caso);
            var atributos = tipo.GetProperties();
            double similaridadeTotal = 0;
            int somaDosPesos = 0;

            foreach (var atributo in atributos)
            {
                var atributoDeSimilaridade = Similaridade.GetAtributoDeSimilaridade(atributo);

                if(atributoDeSimilaridade != null)
                {
                    double similaridade = 0;

                    var v1c1 = atributo.GetValue(caso1);
                    var v1c2 = atributo.GetValue(caso2);

                    if (v1c1 == null || v1c2 == null)
                    {
                        if (v1c1 == v1c2)
                            similaridade = 1;
                        else
                            similaridade = 0;
                    }
                    else
                    {
                        if (atributo.PropertyType == typeof(int?))
                            similaridade = ConsultarSimilaridadeParaTiposInteiros((int)v1c1, (int)v1c2, atributoDeSimilaridade.min, atributoDeSimilaridade.max);

                        else if (atributo.PropertyType == typeof(double?))
                            similaridade = ConsultarSimilaridadeParaTiposDecimais((double)v1c1, (double)v1c2, atributoDeSimilaridade.min, atributoDeSimilaridade.max);

                        else if (atributo.PropertyType == typeof(bool?))
                            similaridade = ConsultarSimilaridadeParaTiposBooleanos((bool)v1c1, (bool)v1c2);
                    }

                    somaDosPesos += atributoDeSimilaridade?.peso ?? 1;
                    similaridadeTotal += atributoDeSimilaridade.peso * similaridade;
                }
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

        /*
         - Ordenar os itens com base no score.
         */
    }
}
