using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;


namespace VULauncher.Views.Controls.Consoles
{
    public sealed class ConsoleOutput : RichTextBox
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource",
            typeof(IEnumerable),
            typeof(ConsoleOutput),
            new PropertyMetadata(default(IEnumerable), OnItemsSourceChanged));

        private Paragraph _paragraph;

        private INotifyCollectionChanged _notifyChanged;

        public ConsoleOutput()
        {
            _paragraph = new Paragraph();

            IsUndoEnabled = false;

            Document = new FlowDocument(_paragraph);

            TextChanged += (s, e) =>
            {
                CheckLinesLimits();
            };

            DataObject.AddCopyingHandler(this, CopyCommand);
        }

        private void CheckLinesLimits()
        {
            if (_paragraph.Inlines.Where(x => x is LineBreak).Count() >= 500)
            {
                _paragraph.Inlines.Remove(_paragraph.Inlines.FirstInline);
            }
        }

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs args)
        {
            base.OnPreviewKeyDown(args);

            switch (args.Key)
            {
                case Key.A:
                    args.Handled = HandleSelectAllKeys();
                    break;
                case Key.C:
                    args.Handled = HandleCopyKeys(args);
                    break;
            }
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue == args.OldValue) return;

            var terminal = (ConsoleOutput)d;
            terminal.HandleItemsSourceChanged((IEnumerable)args.NewValue);
            terminal.ScrollToEnd();
        }

        private void CopyCommand(object sender, DataObjectCopyingEventArgs args)
        {
            if (!string.IsNullOrEmpty(Selection.Text)) args.DataObject.SetData(typeof(string), Selection.Text);

            args.Handled = true;
        }

        private void HandleItemsSourceChanged(IEnumerable items)
        {
            using (DeclareChangeBlock())
            {
                if (items is INotifyCollectionChanged changed)
                {
                    var notifyChanged = changed;
                    if (_notifyChanged != null) _notifyChanged.CollectionChanged -= HandleItemsChanged;

                    _notifyChanged = notifyChanged;
                    _notifyChanged.CollectionChanged += HandleItemsChanged;

                    var existingItems = items.Cast<Inline>().ToArray();
                    if (existingItems.Any())
                        ReplaceItems(existingItems);
                    else
                        ClearItems();
                }
                else
                {
                    ReplaceItems(ItemsSource.Cast<Inline>().ToArray());
                }
            }
        }

        private void HandleItemsChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddItems(args.NewItems.Cast<Inline>().ToArray());
                    break;
            }
        }

        private void ClearItems()
        {
            _paragraph.Inlines.Clear();
        }

        private void ReplaceItems(Inline[] items)
        {
            _paragraph.Inlines.Clear();

            AddItems(items);
        }

        private void AddItems(Inline[] items)
        {
            if (CheckAccess())
            {
                Dispatcher.Invoke(() =>
                {
                    CaretPosition = CaretPosition.DocumentEnd;

                    var inlines = new List<Inline>();

                    foreach (var item in items)
                    {
                        inlines.Add(item);
                    }

                    _paragraph.Inlines.AddRange(inlines);

                    CaretPosition = Document.ContentEnd;
                });
            }
        }

        private bool HandleCopyKeys(KeyEventArgs args)
        {
            if (args.Key == Key.C)
            {
                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) return false;

                var promptEnd = Document.ContentEnd;

                var pos = CaretPosition.CompareTo(promptEnd);
                var selectionPos = Selection.Start.CompareTo(CaretPosition);

                return pos < 0 || selectionPos < 0;
            }

            return false;
        }

        private bool HandleSelectAllKeys()
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                Selection.Select(Document.ContentStart, Document.ContentEnd);

                return true;
            }

            return HandleAnyOtherKey();
        }

        private bool HandleAnyOtherKey()
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) return false;

            var pos = CaretPosition.CompareTo(Document.ContentEnd);
            return pos < 0;
        }
    }
}
