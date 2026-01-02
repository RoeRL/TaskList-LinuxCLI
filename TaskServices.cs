using System;
using TaskList.Models;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace TaskList.Services
{
    public class TaskService
    {
        private static string _mHomePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private static string _mFolderPath = Path.Combine(_mHomePath, ".config", "tasklist");
        private static string _mFilePath = Path.Combine(_mFolderPath, "task.json");
        private string _defaultJsonContent = "{}";
        
        public void AddTask()
        {
            
            if (!Directory.Exists(_mFolderPath)) Directory.CreateDirectory(_mFolderPath);
            if (!File.Exists(_mFilePath)) File.WriteAllText(_mFilePath, _defaultJsonContent);
            Guid uniqueId = Guid.NewGuid();
            string newUid = uniqueId.ToString();
            Console.WriteLine("Enter the Task Title: ");
            string mTitle = Console.ReadLine();
            string oldJsonString = File.ReadAllText(_mFilePath);
            string formattedJsonString = JValue.Parse(oldJsonString).ToString(Formatting.Indented);
            TaskModel taskModel = new TaskModel
            {
                Id = newUid,
                Title = mTitle,
                Description = "NONE",
                IsComplete = true,
                CreatedAt = DateTime.Now

            };
            string json = JsonConvert.SerializeObject(taskModel, Formatting.Indented);
            string fullJson = json + "\n" + formattedJsonString;   
            Console.WriteLine(fullJson);
            File.WriteAllText(_mFilePath, fullJson);
        }
    }
}