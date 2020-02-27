using System;
using System.Windows.Controls;

namespace VULauncher.Views.Common
{
    public static class GridExtensions
    {
        public static void SelectLastRow(DataGrid dataGrid)
        {
            if (dataGrid.Items.Count == 0)
                return;

            SelectRowByIndex(dataGrid, dataGrid.Items.Count - 1);
            dataGrid.Focus();
            dataGrid.BeginEdit();
        }

        public static void SelectRowByIndex(DataGrid dataGrid, int rowIndex)
        {
            if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.FullRow))
            {
                throw new ArgumentException("The SelectionUnit of the DataGrid must be set to FullRow.");
            }

            if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
            {
                throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));
            }

            dataGrid.SelectedItems.Clear();
            object item = dataGrid.Items[rowIndex];
            dataGrid.SelectedItem = item;

            DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            if (row == null)
            {
                dataGrid.ScrollIntoView(item);
                row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            }
        }
    }
}
