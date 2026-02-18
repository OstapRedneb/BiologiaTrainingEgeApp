using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologiaTrainingEgeApp.Classes
{
    public class User
    {
        public Guid Id { get; init; }
        public string Login { get; init; }
        public string Password { get; init; }
        public int CountTasks { get; set; }
        public bool IsAdmin { get; set; }
    }
}
