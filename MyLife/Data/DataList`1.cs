// <copyright file="DataList`1.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    public class DataList<T> : IList<T>, INotifyCollectionChanged
    {
        private readonly List<T> backingList = new List<T>();

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public int Count
        {
            get { return this.backingList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public T this[int index]
        {
            get
            {
                return this.backingList[index];
            }

            set
            {
                var oldItem = this.backingList[index];
                this.backingList[index] = value;
                this.RaiseCollectionChanged(
                    () => new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, oldItem, index));
            }
        }

        public int IndexOf(T item)
        {
            return this.backingList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.backingList.Insert(index, item);
            this.RaiseCollectionChanged(
                () => new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
        }

        public void RemoveAt(int index)
        {
            var oldItem = this.backingList[index];
            this.backingList.RemoveAt(index);
            this.RaiseCollectionChanged(
                () => new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItem, index));
        }

        public void Add(T item)
        {
            var newIndex = this.backingList.Count;
            this.backingList.Add(item);
            this.RaiseCollectionChanged(
                () => new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, newIndex));
        }

        public void Clear()
        {
            this.backingList.Clear();
            this.RaiseCollectionChanged(
                () => new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(T item)
        {
            return this.backingList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.backingList.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            var index = this.backingList.IndexOf(item);
            if (index != -1)
            {
                this.RemoveAt(index);
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.backingList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.backingList).GetEnumerator();
        }

        private void RaiseCollectionChanged(Func<NotifyCollectionChangedEventArgs> e)
        {
            var c = this.CollectionChanged;
            if (c != null)
            {
                c(this, e());
            }
        }
    }
}
