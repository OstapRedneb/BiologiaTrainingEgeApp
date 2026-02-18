using BiologiaTrainingEgeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologiaTrainingEgeApp.Classes
{
    public record TaskWithTables(int Number, string Text, string[,] Table, string Answer) : Task(Number, Text, Answer);
}
