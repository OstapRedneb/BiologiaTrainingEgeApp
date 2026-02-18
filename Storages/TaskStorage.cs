using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BiologiaTrainingEgeApp.Storages
{
    public static class TaskStorage
    {
        private static readonly string _path = "tsaks";

        public static List<Task> GetAll() =>
            JsonConvert.DeserializeObject<List<Task>>(_path) ?? new List<Task>();

        public static void WriteInto(List<Task> tasks) 
        {
            string blob = JsonConvert.SerializeObject(tasks ?? new List<Task>());
            using (StringWriter stringWriter = new StringWriter()) 
            {
                stringWriter.Write(blob);
            }
        }
    }
}
