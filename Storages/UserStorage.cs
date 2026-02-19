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

        public static bool Add(User user) 
        {
            List<User> users = GetAll();

            if (users.Any(user => user.Login == user.Login))
                return false;

            users.Add(user);

            WriteInto(users);

            return true;
        }

        public static bool AddRange(params User[] users) 
        {
            return users.All(user => Add(user));
        }

        private static void WriteInto(List<User> tasks) 
        {
            string blob = JsonConvert.SerializeObject(tasks ?? new List<User>());
            using (StreamWriter stringWriter = new StreamWriter(_path, false)) 
            {
                stringWriter.Write(blob);
            }
        }
    }
}
