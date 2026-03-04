using BiologiaTrainingEgeApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologiaTrainingEgeApp.Classes
{
    [Serializable]
    public class TextBlock : TaskBlock
    {
        public string Content { get; set; }
        public TextBlock()
        {
            Type = BlockType.Text;
        }
    }
}
