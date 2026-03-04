using BiologiaTrainingEgeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiologiaTrainingEgeApp.Enums;

namespace BiologiaTrainingEgeApp.Classes
{
    [Serializable]
    public class TaskData
    {
        
        public string TaskTitle { get; set; }              // Название/тема задания
        public string QuestionText { get; set; }            // Текст вопроса
        public List<TaskBlock> Blocks { get; set; }         // Блоки с содержимым
        public DateTime CreatedDate { get; set; }           // Дата создания
        public DateTime ModifiedDate { get; set; }          // Дата изменения
        public Guid TaskId { get; set; }                  // Уникальный идентификатор

        public TaskData()
        {
            Blocks = new List<TaskBlock>();
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            TaskId = Guid.NewGuid();
        }
    }
}
