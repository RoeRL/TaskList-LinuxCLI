using System;
using Newtonsoft.Json;


namespace TaskList.Models
{
    public class TaskModel
    {
        [JsonProperty("task_id")]
        public string Id {get; set;} = string.Empty;

        [JsonProperty("task_title")]
        public string Title {get; set;} = string.Empty;

        [JsonProperty("task_desc")]
        public string Description {get; set;} = string.Empty;

        [JsonProperty("task_status")]
        public bool IsComplete {get; set;}

        [JsonProperty("task_created")]
        public DateTime CreatedAt {get; set;}
    }
}