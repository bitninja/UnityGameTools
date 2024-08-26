using System;
using System.Collections.Generic;

namespace UnityGameTools
{

    public static class CollectionUtils
    {
        /// <summary>
        /// List.sort uses Array.sort which is a fast unstable sort, thus it is possible to get ordering differences
        /// between runs of the game, this is a problem for repeatable randomness when using Unity random seeds.
        /// This method uses Unity randomness to shuffle the array in place.  No new instances were created or harmed
        /// in the use of this method. :P
        /// </summary>
        public static void Randomize<T>(T[] array)
        {
            if (array == null)
            {
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                var first = array[i];
                var randIndex = UnityEngine.Random.Range(0, array.Length);
                array[i] = array[randIndex];
                array[randIndex] = first;
            }
        }

        /// <summary>
        /// Convenience method to insert a supplied value to the dictionary if the specified key does
        /// not have an associated value.
        /// </summary>
        public static V GetOrCreateValue<K,V>(this IDictionary<K,V> dict, K key, Func<K,V> create)
        {
            if (!dict.TryGetValue(key, out var val))
            {
                val = create(key);
                dict[key] = val;
            }

            return val;
        }
    }
}