using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.Views.Common
{
    public class VULauncherPage : Page // cant be abstract because of XAML Designer complaining. do not initiate directly
    {
        //protected PageViewModel ViewModel => DataContext as PageViewModel;

        protected void OnPreviewKeyDown(object sender, KeyEventArgs e, Action<IUserCreatableItem> deleteItemAction, ref bool isEditing)
        {
            var dataGrid = sender as DataGrid;

            if (dataGrid == null)
                return;

            if (isEditing || e.Key != Key.Delete) return;

            var item = dataGrid.SelectedItem as IUserCreatableItem;

            if (item == null)
            {
                return;
            }

            deleteItemAction(item);
            e.Handled = true;
            return;
        }

        protected void OnBeginningEdit(ref bool isEditing)
        {
            isEditing = true;
        }

        protected void OnRowEditEnding(object sender, DataGridRowEditEndingEventArgs e, ref bool isEditing)
        {
            var dataGrid = sender as DataGrid;

            if (e.EditAction == DataGridEditAction.Commit)
            {
                var bindingGroup = e.Row.BindingGroup;
                if (bindingGroup != null && bindingGroup.CommitEdit())
                {
                    var item = (IUserCreatableItem)e.Row.Item;
                    if (item.IsEmptyItem)
                    {
                        e.Cancel = true;
                        dataGrid?.CancelEdit();
                    }
                }
            }

            isEditing = false;
        }

        protected void OnDeleteButtonClick(DataGrid dataGrid, Action<IUserCreatableItem> deleteItemAction)
        {
            Dispatcher?.BeginInvoke(DispatcherPriority.Input, new Action(() =>
                                                                         {
                                                                             var item = dataGrid?.SelectedItem as IUserCreatableItem;

                                                                             if (item == null)
                                                                                 return;

                                                                             deleteItemAction(item);
                                                                             dataGrid.Focus();
                                                                         }));
        }
    }
}
