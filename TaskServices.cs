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
        private static string _mjsonRead = File.ReadAllText(_mFilePath);
        private string _defaultJsonContent = "[{}]";
        
        public void AddTask()
        {
            if (!Directory.Exists(_mFolderPath)) Directory.CreateDirectory(_mFolderPath);
            if (!File.Exists(_mFilePath)) File.WriteAllText(_mFilePath, _defaultJsonContent);
            Guid uniqueId = Guid.NewGuid();
            string newUid = uniqueId.ToString();
            
            Console.WriteLine("Enter the Task Title: ");
            string mTitle = Console.ReadLine() ?? "No Title";
            Console.WriteLine("Enter the Task Description: ");
            string mDescription = Console.ReadLine() ?? "No Description";
            
            List<TaskModel> oldJson = JsonConvert.DeserializeObject<List<TaskModel>>(_mjsonRead) ?? new List<TaskModel>();
            oldJson.Add(new TaskModel
            {
                Id = newUid,
                Title = mTitle,
                Description = mDescription,
                IsComplete = false,
                CreatedAt = DateTime.Now
            });
            
            string updatedJsonString = JsonConvert.SerializeObject(oldJson,  Formatting.Indented);
            Console.WriteLine(updatedJsonString);
            File.WriteAllText(_mFilePath, updatedJsonString);
        }
        
        public void ReadTask()
        {
            if (!Directory.Exists(_mFolderPath)) Directory.CreateDirectory(_mFolderPath);
            if (!File.Exists(_mFilePath)) File.WriteAllText(_mFilePath, _defaultJsonContent);
            List<TaskModel> oldJson = JsonConvert.DeserializeObject<List<TaskModel>>(_mjsonRead) ?? new List<TaskModel>();
            
            string fullJsonRead = JsonConvert.SerializeObject(oldJson,  Formatting.Indented);
            Console.WriteLine(fullJsonRead);
        }
    }
}