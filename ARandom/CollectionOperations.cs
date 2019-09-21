using System.Collections.Generic;
using System.Linq;

namespace ARandom
{
    public partial class RandomGenerator
    {
        /// <summary>
        /// Gets random element from the collection.
        /// </summary>
        /// <typeparam name="T">The element type of the collection.</typeparam>
        /// <param name="collection">Collection to acquire element from.</param>
        /// <returns>Random element from input collection.</returns>
        public T GetRandom<T>(IEnumerable<T> collection)
        {
            int index = this.Next(0, collection.Count());
            return collection.ElementAt(index);
        }

        /// <summary>
        /// Shuffles an array.
        /// </summary>
        /// <typeparam name="T">The element type of the array.</typeparam>
        /// <param name="array">Array to shuffle.</param>
        /// <seealso cref="ShuffleArray{T}(T[], int, int)"/>
        public void ShuffleArray<T>(T[] array) => ShuffleArray(array, 0, array.Length);

        /// <summary>
        /// Shuffles an array in specified range.
        /// </summary>
        /// <typeparam name="T">The element type of the array.</typeparam>
        /// <param name="array">Array to shuffle.</param>
        /// <param name="start">Upper inclusive bound of range.</param>
        /// <param name="end">Bottom exclusive bound of range.</param>
        public void ShuffleArray<T>(T[] array, int start, int end)
        {
            T temp;
            int index;

            int n = end;
            while(n > start + 1)
            {
                index = this.Next(n--);
                temp = array[n];
                array[n] = array[index];
                array[index] = temp;
            }
        }

        /// <summary>
        /// Creates collection which is shuffled version of input one.
        /// </summary>
        /// <typeparam name="T">The element type of the collections.</typeparam>
        /// <param name="collection">Collection to be shuffled.</param>
        /// <returns>Shuffled version of input collection.</returns>
        public IEnumerable<T> Shuffle<T>(IEnumerable<T> collection)
        {
            var temp = collection.ToList();

            for (int i = 0; i < temp.Count; i++)
            {
                int j = this.Next(i, temp.Count);
                yield return temp[j];

                temp[j] = temp[i];
            }
        }
    }
}