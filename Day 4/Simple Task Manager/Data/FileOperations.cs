using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SimpleTaskManager.Models;

namespace SimpleTaskManager.Data
{
    public class FileOperations
    {
        private const string _fileName = "tasks.csv";

        public async Task SaveTasks(List<TaskItem> tasks)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_fileName))
                {
                    foreach (var taskItem in tasks)
                    {
                        await writer.WriteLineAsync(taskItem.ToString());
                    }
                }

                Console.WriteLine("Tasks saved successfully");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error saving tasks to the file: {ex.Message}");
            }
        }

        public async Task<List<TaskItem>> LoadTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            try
            {
                if (!File.Exists(_fileName))
                {
                    return tasks;
                }

                using (StreamReader reader = new StreamReader(_fileName))
                {
                    string line;

                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] taskDetails = line.Split(',');

                        TaskItem taskItem = new TaskItem {
                            Name = taskDetails[0],
                            Description = taskDetails[1],
                            Category = (TaskCategory)Enum.Parse(typeof(TaskCategory), taskDetails[2]),
                            IsCompleted = bool.Parse(taskDetails[3])
                        };

                        tasks.Add(taskItem);

                        }

                    }
                }
                
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading tasks from the file: {ex.Message}");
                }

                return tasks;
        }
    }
}

