using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiologiaTrainingEgeApp.Classes;
using Newtonsoft.Json;

namespace BiologiaTrainingEgeApp.Storages
{
    public static class UserStorage
    {
        private static readonly string _path = "users";

        public static List<User> GetAll() =>
            JsonConvert.DeserializeObject<List<User>>(_path) ?? new List<User>();

        public static void WriteInto(List<User> tasks) 
        {
            string blob = JsonConvert.SerializeObject(tasks ?? new List<User>());
            using (StringWriter stringWriter = new StringWriter()) 
            {
                stringWriter.Write(blob);
            }
        }
    }
}
