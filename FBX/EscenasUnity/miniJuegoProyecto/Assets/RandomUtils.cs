using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace GTI4.Utils
{
    public class RandomUtils
    {

        public static T Choose<T>(IList<T> options)
        {
            return options[Random.Range(0, options.Count)];
        }

        public static void Shuffle<T> (IList<T> options)
        {
            int n = options.Count;
            while( n > 0)
            {
                n--;
                int k = Random.Range(0, n + 1);
                T temp = options[n];
                options[n] = options[k];
                options[k] = temp;
            }
        }

        public static T RandomWeighted<T> (Dictionary<T, int> options)
        {
            int totalPesos = options.Values.Sum(); // suma los valores enteros de todo el diccionario
            int k = Random.Range(0, totalPesos);
            foreach(KeyValuePair<T, int> item in options)
            {
                if( k < item.Value)
                {
                    return item.Key;
                }
                else
                {
                    k -= item.Value;
                }
            }

            return default(T);
        }

    }
}

