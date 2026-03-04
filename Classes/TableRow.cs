using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologiaTrainingEgeApp.Classes
{
    [Serializable]
    public class TableRow
    {
        public int Height { get; set; }
        public List<string> Cells { get; set; }

        public TableRow()
        {
            Cells = new List<string>();
        }
    }
}
