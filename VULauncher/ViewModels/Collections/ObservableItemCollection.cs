using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using VULauncher.ViewModels.Common;

namespace VULauncher.ViewModels.Collections
{
    public interface IObservableItemCollection
    {
        event EventHandler<ItemPropertyChangedEventArgs> ItemPropertyChanged;
        event EventHandler<IsDirtyChangedEventArgs> ItemIsDirtyChanged;
        bool IsDirty { get; }
    }

    public class ObservableItemCollection<T> : WpfObservableRangeCollection<T>, IObservableItemCollection
        where T : IObservableObject

    {
        public bool IsDirty => this.Any(item => item.IsDirty);

        public event EventHandler<ItemPropertyChangedEventArgs> ItemPropertyChanged;
        public event EventHandler<IsDirtyChangedEventArgs> ItemIsDirtyChanged;

        public ObservableItemCollection() : base()
        {
        }

        public ObservableItemCollection(List<T> list) : base(list)
        {
            ObserveAll();
        }

        public ObservableItemCollection(IEnumerable<T> enumerable) : base(enumerable)
        {
            ObserveAll();
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove ||
                e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (T item in e.OldItems)
                {
                    item.PropertyChanged -= ChildPropertyChanged;
                    item.IsDirtyChanged -= ChildIsDirtyChanged;
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Add ||
                e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (T item in e.NewItems)
                {
                    item.PropertyChanged += ChildPropertyChanged;
                    item.IsDirtyChanged += ChildIsDirtyChanged;
                }
            }

            base.OnCollectionChanged(e);
        }

        protected override void ClearItems()
        {
            foreach (T item in Items)
                item.PropertyChanged -= ChildPropertyChanged;

            base.ClearItems();
        }

        private void ObserveAll()
        {
            foreach (T item in Items)
                item.PropertyChanged += ChildPropertyChanged;
        }

        private void ChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            T typedSender = (T)sender;
            int i = Items.IndexOf(typedSender);

            if (i < 0)
                throw new ArgumentException("Received property notification from item not in collection");

            OnItemPropertyChanged(i, e);
        }

        protected void OnItemPropertyChanged(ItemPropertyChangedEventArgs e)
        {
            ItemPropertyChanged?.Invoke(this, e);
        }

        protected void OnItemPropertyChanged(int index, PropertyChangedEventArgs e)
        {
            OnItemPropertyChanged(new ItemPropertyChangedEventArgs(index, e));
        }

        private void ChildIsDirtyChanged(object sender, IsDirtyChangedEventArgs e)
        {
            OnItemIsDirtyChanged(e);
        }

        protected void OnItemIsDirtyChanged(IsDirtyChangedEventArgs e)
        {
            ItemIsDirtyChanged?.Invoke(this, e);
        }
    }

    public class ItemPropertyChangedEventArgs : PropertyChangedEventArgs
    {
        public int CollectionIndex { get; }

        public ItemPropertyChangedEventArgs(int index, string name) : base(name)
        {
            CollectionIndex = index;
        }

        public ItemPropertyChangedEventArgs(int index, PropertyChangedEventArgs args) : this(index, args.PropertyName)
        {
        }
    }
}
