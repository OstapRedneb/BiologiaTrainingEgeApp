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
        private static readonly string _path = "tasks";

        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented 
        };

        public static List<TaskData> GetAll()
        {
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                return JsonConvert.DeserializeObject<List<TaskData>>(json, _settings) ?? new List<TaskData>();
            }
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
            string blob = JsonConvert.SerializeObject(tasks ?? new List<TaskData>(), _settings);
            File.WriteAllText(_path, blob);
        }
    }
}
