namespace DelegatesAndEvents
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <inheritdoc cref="IObservableList{T}" />
    public class ObservableList<TItem> : IObservableList<TItem>, IEquatable<ObservableList<TItem>>
    {
        /// <inheritdoc cref="IObservableList{T}.ElementInserted" />
        public event ListChangeCallback<TItem> ElementInserted;

        /// <inheritdoc cref="IObservableList{T}.ElementRemoved" />
        public event ListChangeCallback<TItem> ElementRemoved;

        /// <inheritdoc cref="IObservableList{T}.ElementChanged" />
        public event ListElementChangeCallback<TItem> ElementChanged;

        private List<TItem> _list = new List<TItem>();

        /// <inheritdoc cref="ICollection{T}.Count" />
        public int Count => this._list.Count;

        /// <inheritdoc cref="ICollection{T}.IsReadOnly" />
        public bool IsReadOnly => false;

        /// <inheritdoc cref="IList{T}.this" />
        public TItem this[int index]
        {
            get => this._list[index];
            set
            {
                this.ElementChanged?.Invoke(this, value, this._list[index], index);
                this._list[index] = value;
            }
        }

        /// <inheritdoc cref="IEnumerable{T}.GetEnumerator" />
        public IEnumerator<TItem> GetEnumerator() => this._list.GetEnumerator();

        /// <inheritdoc cref="IEnumerable.GetEnumerator" />
        IEnumerator IEnumerable.GetEnumerator() => this._list.GetEnumerator();

        /// <inheritdoc cref="ICollection{T}.Add" />
        public void Add(TItem item)
        {
            var index = this._list.Count;
            this._list.Add(item);
            this.ElementInserted?.Invoke(this, item, index);
        }

        /// <inheritdoc cref="ICollection{T}.Clear" />
        public void Clear()
        {
            for (var i = 0; i < this._list.Count; i++)
            {
                this.Remove(this._list[0]);
            }
        }

        /// <inheritdoc cref="ICollection{T}.Contains" />
        public bool Contains(TItem item) => this._list.Contains(item);

        /// <inheritdoc cref="ICollection{T}.CopyTo" />
        public void CopyTo(TItem[] array, int arrayIndex) => this._list.CopyTo(array, arrayIndex);

        /// <inheritdoc cref="ICollection{T}.Remove" />
        public bool Remove(TItem item)
        {
            var index = _list.IndexOf(item);
            if (!this._list.Remove(item)) return false;
            this.ElementRemoved?.Invoke(this, item, index);
            return true;

        }

        /// <inheritdoc cref="IList{T}.IndexOf" />
        public int IndexOf(TItem item) => this._list.IndexOf(item);

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void Insert(int index, TItem item)
        {
            this._list.Insert(index, item);
            this.ElementInserted?.Invoke(this, item, index);
        }

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void RemoveAt(int index)
        {
            var elem = this._list[index];
            this._list.RemoveAt(index);
            this.ElementRemoved?.Invoke(this, elem, index);
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ObservableList<TItem>) obj);
        }

        public bool Equals(ObservableList<TItem> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_list, other._list);
        }

        /// <inheritdoc cref="object.GetHashCode" />
        public override int GetHashCode() => (_list != null ? _list.GetHashCode() : 0);

        /// <inheritdoc cref="object.ToString" />
        public override string ToString()
        {
            return $"{nameof(_list)}: {_list}";
        }
    }
}
