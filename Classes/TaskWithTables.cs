using BiologiaTrainingEgeApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologiaTrainingEgeApp.Classes
{
    public record TaskWithTables(Tasks Number, string Text, string[,] Table, string Answer) : Task(Number, Text, Answer);
}
