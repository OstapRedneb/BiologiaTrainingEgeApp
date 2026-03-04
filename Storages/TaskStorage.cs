using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiologiaTrainingEgeApp.Classes;
using Newtonsoft.Json;

namespace BiologiaTrainingEgeApp.Storages
{
    public static class TaskStorage
    {
        private static readonly string _path = "tsaks";

        public static List<TaskData> GetAll()
        {
            if (File.Exists(_path))
                return JsonConvert.DeserializeObject<List<TaskData>>(File.ReadAllText(_path)) ?? new List<TaskData>();
            return new List<TaskData>();
        }

        public static bool Add(TaskData task)
        {
            List<TaskData> tasks = GetAll();

            if (tasks.Contains(task))
                return false;

            tasks.Add(task);

            WriteInto(tasks);

            return true;
        }

        public static bool AddRange(params TaskData[] tasks)
        {
            return tasks.All(task => Add(task));
        }

        private static void WriteInto(List<TaskData> tasks) 
        {
            string blob = JsonConvert.SerializeObject(tasks ?? new List<TaskData>());
            using (StreamWriter stringWriter = new StreamWriter(_path, false)) 
            {
                stringWriter.Write(blob);
            }
        }
    }
}
