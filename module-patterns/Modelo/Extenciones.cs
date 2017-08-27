using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    static class Extenciones
    {
        public static List<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList<T>();
        }

        public static List<T> CloneNode<T>(this IList<T> listToClone)
        {
            return listToClone.Select(item => item).ToList<T>();
        }
    }
}
