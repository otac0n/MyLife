// <copyright file="Database.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife
{
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections.Specialized;
    using System.Collections;

    public partial class Database
    {
        private const string DatabaseFileName = "Database.v1.xml";

        private static readonly DataContractSerializer serializer = new DataContractSerializer(typeof(Database));

        public Database()
        {
        }

        public static void Save(Database db)
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var file = storage.OpenFile(DatabaseFileName, FileMode.Create))
                {
                    serializer.WriteObject(file, db);
                }
            }
        }

        public static Database Load()
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!storage.FileExists(DatabaseFileName))
                {
                    return new Database();
                }

#if DEBUG
                using (var file = storage.OpenFile(DatabaseFileName, FileMode.Open))
                {
                    using (var reader = new StreamReader(file))
                    {
                        System.Diagnostics.Debug.WriteLine(reader.ReadToEnd());
                    }
                }
#endif

                using (var file = storage.OpenFile(DatabaseFileName, FileMode.Open))
                {
                    return (Database)serializer.ReadObject(file);
                }
            }
        }

        public class DataList<T> : IList<T>, INotifyCollectionChanged
        {
            private readonly List<T> backingList = new List<T>();

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

            public int Count
            {
                get { return this.backingList.Count; }
            }

            public bool IsReadOnly
            {
                get { return false; }
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

            public event NotifyCollectionChangedEventHandler CollectionChanged;

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
}
