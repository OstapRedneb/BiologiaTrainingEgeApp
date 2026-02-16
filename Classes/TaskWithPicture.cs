using BiologiaTrainingEgeApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologiaTrainingEgeApp.Classes
{
    public record TaskWithPicture(Tasks Number, string Text, PictureBox Picture, string Answer) : Task(Number, Text, Answer);
}
