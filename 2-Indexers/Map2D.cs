namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        private List<Tuple<TKey1, TKey2, TValue>> map = new List<Tuple<TKey1, TKey2, TValue>>();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements => map.Count();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get => this.map.FindAll(x => x.Item1.Equals(key1)).Find(x => x.Item2.Equals(key2)).Item3;

            set => this.map.Add(new Tuple<TKey1, TKey2, TValue>(key1, key2, value));
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            return this.map
                .Where(x => x.Item1.Equals(key1))
                .Select(x => new Tuple<TKey2, TValue>(x.Item2, x.Item3))
                .ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            return this.map
                .Where(x => x.Item2.Equals(key2))
                .Select(x => new Tuple<TKey1, TValue>(x.Item1, x.Item3))
                .ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements() => this.map;
        // copia difensiva

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            // cast to list

            foreach (var key1 in keys1)
            {
                foreach (var key2 in keys2)
                {
                    this.map.Add(new Tuple<TKey1, TKey2, TValue>(key1, key2, generator(key1, key2)));
                }
            }



        }

        // TODO: rigenerare Equals
        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            // TODO: improve
            return base.Equals(other);
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            // TODO: improve
            return base.Equals(obj);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            // TODO: improve
            return base.GetHashCode();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            // TODO: improve
            return base.ToString();
        }
    }
}
