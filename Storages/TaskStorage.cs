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

        public static bool Add(Task task)
        {
            List<Task> tasks = GetAll();

            if (tasks.Contains(task))
                return false;

            tasks.Add(task);

            WriteInto(tasks);

            return true;
        }

        public static bool AddRange(params Task[] tasks)
        {
            return tasks.All(task => Add(task));
        }

        private static void WriteInto(List<Task> tasks) 
        {
            string blob = JsonConvert.SerializeObject(tasks ?? new List<Task>());
            using (StreamWriter stringWriter = new StreamWriter(_path, false)) 
            {
                stringWriter.Write(blob);
            }
        }
    }
}
