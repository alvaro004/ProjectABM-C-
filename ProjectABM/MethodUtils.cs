using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectABM
{
    public static class MethodUtils
    {
        public static void PreventIdEditing(DataGridView gridView, string idColumnName)
        {
            gridView.CellEnter += (sender, e) =>
            {
                if (e.ColumnIndex == gridView.Columns[idColumnName].Index)
                {
                    gridView.CurrentCell.ReadOnly = true;
                }
                else
                {
                    gridView.CurrentCell.ReadOnly = false;
                }
            };
        }
    }
}
