namespace Iterators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The runnable entrypoint of the exercise.
    /// </summary>
    public class Program
    {
        /// <inheritdoc cref="Program" />
        public static void Main()
        {

            var elem = Java8StreamOperations.Range(0, 4).ToList();
            var sum = elem.Reduce(0, (x, y) => x + y);
            Console.WriteLine("SUM :  " + sum);
            const int len = 50;
            int?[] numbers = new int?[len];
            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                if (rand.NextDouble() > 0.2)
                {
                    numbers[i] = rand.Next(len);
                }
            }

            // TODO rewrite using methods from Java8StreamOperations

            IDictionary<int, int> occurrences = numbers
                .Map(optN => {
                    Console.Write(optN.ToString() + ",");
                    return optN;
                })
                .SkipSome(1)
                .TakeSome(len - 2)
                .Filter(optN => optN.HasValue)
                .Map(optN => optN.Value)
                .Reduce(new Dictionary<int, int>(), (d, n) =>
                {
                    d[n] = d.ContainsKey(n) ? d[n] + 1 : 1;
                    return d;
                });

            Console.WriteLine();

            occurrences.ForEach(x => Console.WriteLine(x));
        }
    }
}
