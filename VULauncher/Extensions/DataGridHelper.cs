using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace VULauncher.Extensions
{
    public static class DataGridHelper
    {
        public static DataGridCell GetCell(this DataGrid grid, DataGridRow row, int column)
        {
            if (row == null) return null;

            DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);

            return (DataGridCell) presenter?.ItemContainerGenerator.ContainerFromIndex(column);
        }

        public static DataGridRow GetRow(this DataGrid dataGrid, int rowIndex)
        {
            DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            if (row == null)
            {
                dataGrid.UpdateLayout();
                row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            }

            return row;
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
    }
}
