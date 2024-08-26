using System.Linq;
using System.Collections.Generic;

namespace UnityGameTools
{
    /**
    This class is designed to manage randomness in a way that aligns with human perception
    of fairness. Pure randomness can sometimes produce results that appear non-random over
    a small number of occurrences, leading to the perception of unfairness. This class
    ensures that the distribution of outcomes feels more balanced, especially in situations
    where the number of occurrences is relatively low.

    Note that this uses the UnityEngine.Random class and thus can also follow repeatable
    randomness patterns if UnityEngine.Random.Seed is set.

    **/
    public class ShuffleBag<T>
    {
        public interface IShuffleBagEntry
        {
            int OccurenceCount { get; }
            T Item { get; }
        }

        private IEnumerator<T> _entriesEnumerator;

        public ShuffleBag(IEnumerable<IShuffleBagEntry> entriesWithCounts)
        {
            _entriesEnumerator = CreateEnumerator(entriesWithCounts);
        }

        public virtual T Next
        {
            get
            {
                _entriesEnumerator.MoveNext();
                return _entriesEnumerator.Current;
            }
        }

        protected virtual IEnumerator<T> CreateEnumerator(IEnumerable<IShuffleBagEntry> entriesWithCounts)
        {
            // Primary reason for using the enumerator approach is to avoid instantiation of new query
            // with each ordered sort.  This is what occurs if you use linq orderby.

            var allEntries = entriesWithCounts.SelectMany(e => Enumerable.Range(0, e.OccurenceCount).Select(r => (T)e.Item)).ToList();
            var indices = Enumerable.Range(0, allEntries.Count).ToArray();

            for (int index = 0; index < allEntries.Count; index++)
            {
                if (index == 0)
                {
                    Randomize(indices);
                }

                yield return allEntries[indices[index]];

                if (index == allEntries.Count - 1)
                {
                    index = 0;
                }
            }
        }

        protected virtual void Randomize(int[] values)
        {
            CollectionUtils.Randomize(values);
        }
    }
}
