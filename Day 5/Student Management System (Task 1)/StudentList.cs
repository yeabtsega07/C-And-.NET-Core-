// StudentList.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

public class StudentList<T>
{
    private List<T> students;

    public StudentList()
    {
        students = new List<T>();
    }

    public void AddStudent(T student)
    {
        students.Add(student);
    }

    public void DisplayAllStudents()
    {
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.GetType().GetProperty("Name").GetValue(student)}, " +
                            $"Age: {student.GetType().GetProperty("Age").GetValue(student)}, " +
                            $"Roll Number: {student.GetType().GetProperty("RollNumber").GetValue(student)}, " +
                            $"Grade: {student.GetType().GetProperty("Grade").GetValue(student)}");
        }
    }

    public T SearchStudent(Func<T, bool> predicate)
    {
        return students.FirstOrDefault(predicate);
    }

    public void SerializeToJson(string filePath)
    {
        string jsonData = JsonSerializer.Serialize(students);
        File.WriteAllText(filePath, jsonData);
    }

    public void DeserializeFromJson(string filePath)
    {
        if (File.Exists(filePath) )
        {
            string jsonData = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<T>>(jsonData);
        }
    }
}
