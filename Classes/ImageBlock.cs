using BiologiaTrainingEgeApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologiaTrainingEgeApp.Classes
{
    [Serializable]
    public class ImageBlock : TaskBlock
    {
        public byte[] ImageData { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public Size ImageSize { get; set; }

        public ImageBlock()
        {
            Type = BlockType.Image;
        }
    }
}
