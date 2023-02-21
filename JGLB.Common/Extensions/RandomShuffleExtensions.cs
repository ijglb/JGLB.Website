using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.Common
{
    public static class RandomShuffleExtensions
    {
        static Random defaultRng = new Random();

        // credit to http://stackoverflow.com/questions/1287567/c-is-using-random-and-orderby-a-good-shuffle-algorithm/1665080#1665080
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            // shuffle the source in place if it implements IList<T> (e.g. List<T> and T[])
            IList<T> elements;
            if (source is IList<T>)
                elements = source as IList<T>;
            else
                elements = source.ToArray();

            // Note i > 0 to avoid final pointless iteration
            for (int i = elements.Count - 1; i > 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
                // we don't actually perform the swap, we can forget about the
                // swapped element because we already returned it.
            }

            // there is one item remaining that was not returned - we return it now
            yield return elements[0];
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) { return source.Shuffle(defaultRng); }
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, int seed) { return source.Shuffle(new Random(seed)); }

        public static IEnumerable<T> ShuffleCopy<T>(this IEnumerable<T> source, Random rng)
        {
            var elements = new List<T>(source);
            return elements.Shuffle(rng);
        }

        public static IEnumerable<T> ShuffleCopy<T>(this IEnumerable<T> source) { return source.ShuffleCopy(defaultRng); }
        public static IEnumerable<T> ShuffleCopy<T>(this IEnumerable<T> source, int seed) { return source.ShuffleCopy(new Random(seed)); }
    }
}
