using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rbc.Models.Util
{
    public static class Util
    {
        public static string ToAnswer(this Boolean? valor)
        {
            if (valor == true)
                return "Sim";
            else if(valor == false)
                return "Não";

            return "?";
        }

        public static string ToAnswer(this int? valor)
        {
            if (valor == null)
                return "?";
            else
                return valor.ToString();
        }

        public static string ToAnswer(this Double? valor)
        {
            if (valor == null)
                return "?";
            else
            {
                double d = (double) valor;
                return d.ToString("N1");
            }
        }

        public static string ToResult(this Boolean? valor)
        {
            if (valor == true)
                return "Positivo";
            else if (valor == false)
                return "Negativo";

            return "?";
        }
    }
}
