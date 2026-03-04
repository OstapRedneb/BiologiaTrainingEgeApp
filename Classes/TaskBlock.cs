using BiologiaTrainingEgeApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologiaTrainingEgeApp.Classes
{
    [Serializable]
    public class TaskBlock
    {
        public BlockType Type { get; set; }
        public int OrderIndex { get; set; }                 // Порядок следования
    }
}
