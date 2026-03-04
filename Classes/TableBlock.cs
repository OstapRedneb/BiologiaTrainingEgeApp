using BiologiaTrainingEgeApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologiaTrainingEgeApp.Classes
{
    [Serializable]
    public class TableBlock : TaskBlock
    {
        public List<TableColumn> Columns { get; set; }        // Колонки
        public List<TableRow> Rows { get; set; }              // Строки
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }

        public TableBlock()
        {
            Type = BlockType.Table;
            Columns = new List<TableColumn>();
            Rows = new List<TableRow>();
        }
    }
}
