using System;
using TaskList.Models;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace TaskList.Services
{
    public class TaskService
    {
        private static string m_homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private static string m_folderPath = Path.Combine(m_homePath, ".config", "tasklist");
        private static string m_filePath = Path.Combine(m_folderPath, "task.json");
        
        public void AddTask()
        {
            string defaultJsonContent = "{}";
            if (!Directory.Exists(m_folderPath)) Directory.CreateDirectory(m_folderPath);
            if (!File.Exists(m_filePath)) File.WriteAllText(m_filePath, defaultJsonContent);
            Guid uniqueId = Guid.NewGuid();
            string newUid = uniqueId.ToString();
            Console.WriteLine("Enter the Task Title: ");
            string m_title = Console.ReadLine();
            string old_jsonString = File.ReadAllText(m_filePath);
            string formattedJsonString = JValue.Parse(old_jsonString).ToString(Formatting.Indented);
            TaskModel taskModel = new TaskModel
            {
                Id = newUid,
                Title = m_title,
                Description = "NONE",
                IsComplete = true,
                CreatedAt = DateTime.Now

            };
            string json = JsonConvert.SerializeObject(taskModel, Formatting.Indented);
            string full_json = json + "\n" + formattedJsonString;   
            Console.WriteLine(full_json);
            File.WriteAllText(m_filePath, full_json);
        }
    }
}