using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using VULauncher.ViewModels.Collections;

namespace VULauncher.ViewModels.Common
{
    public abstract class ItemsParentViewModel : ViewModel
    {
        private readonly List<IObservableObject> _trackedChildItems = new List<IObservableObject>();
        private readonly List<IObservableItemCollection> _trackedChildItemsLists = new List<IObservableItemCollection>();

        public override bool IsDirty
        {
            get => base.IsDirty || AreAnyChildItemsDirty;
            set => base.IsDirty = value;
        }

        private bool AreAnyChildItemsDirty
        {
            get
            {
                return _trackedChildItems.Any(o => o.IsDirty) || _trackedChildItemsLists.Any(col => col.IsDirty);
            }
        }
         
        // This makes sure, that if any IsDirty property of a child item is set to true, the parent's IsDirty also gets set to true.
        // Also, it forwards the ItemPropertyChanged and ItemIsDirtyChanged events as normal PropertyChanged / IsDirtyChanged events for outsiders to catch
        protected void RegisterChildItemCollection(IObservableItemCollection collection)
        {
            _trackedChildItemsLists.Add(collection);

            collection.ItemPropertyChanged += OnChildItemPropertyChanged;
            collection.ItemIsDirtyChanged += OnChildItemIsDirtyChanged;
        }

        protected void RegisterChildItem(IObservableObject item)
        {
            _trackedChildItems.Add(item);

            item.PropertyChanged += OnChildItemPropertyChanged;
            item.IsDirtyChanged += OnChildItemIsDirtyChanged;
        }

        public override void Dispose()
        {
            foreach (IObservableItemCollection collection in _trackedChildItemsLists)
            {
                collection.ItemPropertyChanged -= OnChildItemPropertyChanged;
                collection.ItemIsDirtyChanged -= OnChildItemIsDirtyChanged;
            }

            foreach (IObservableObject observableObject in _trackedChildItems)
            {
                observableObject.PropertyChanged -= OnChildItemPropertyChanged;
                observableObject.IsDirtyChanged -= OnChildItemIsDirtyChanged;
            }

            base.Dispose();
        }

        // This can be used by the derived class to track any specific child item property changing
        protected virtual void OnChildItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName); // TODO XY: Change to the name of the actual object or collection thats being tracked, not its fields?
        }

        // This can be used by the derived class to track any specific child item's IsDirty flag being set
        protected virtual void OnChildItemIsDirtyChanged(object sender, IsDirtyChangedEventArgs e)
        {
            NotifyIsDirtyChanged(e.PropertyName); // TODO XY: Change to the name of the actual object or collection thats being tracked, not its fields?
        }
    }
}
