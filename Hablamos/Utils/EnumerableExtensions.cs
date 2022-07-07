using System.Security.Cryptography;

namespace Hablamos.Utils
{
    internal static class EnumerableExtensions
    {
        internal static T PickRandom<T>(this IList<T> list)
        {
            return list[RandomNumberGenerator.GetInt32(list.Count)];
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                int k = RandomNumberGenerator.GetInt32(n);
                T temp = list[--n];
                list[n] = list[k];
                list[k] = temp;
            }
        }
    }
}
