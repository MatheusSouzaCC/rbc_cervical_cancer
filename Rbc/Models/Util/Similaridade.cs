using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rbc.Models.Util
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class Similaridade : Attribute
    {
        public int peso;

        public Similaridade()
        {
            peso = 1;
        }

        public static Similaridade GetAtributoDeSimilaridade(PropertyInfo tipo)
        {
            var atributosCustomizados = tipo.GetCustomAttributes();
            return (Similaridade)atributosCustomizados?.Where(x => x is Similaridade).FirstOrDefault();
        }
    }
}