// StudentList.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

public class StudentList<T>
{   
    // create a list of Student objects
    private List<T> students;

    public StudentList()
    {
        students = new List<T>();
    }

    // add a new Student object to the list
    public void AddStudent(T student)
    {
        students.Add(student);
    }

    // display all the students in the list
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

    // search for a student by name
    public T SearchStudent(Func<T, bool> predicate, Func<IEnumerable<T>, IOrderedEnumerable<T>> orderBy = null)
    {
        var query = students.Where(predicate);
        
        if (orderBy != null)
        {
            query = orderBy(query);
        }

        return query.FirstOrDefault();
    }

    //  serialize the list to JSON
    public void SerializeToJson(string filePath)
    {
        string jsonData = JsonSerializer.Serialize(students);
        File.WriteAllText(filePath, jsonData);
    }

    // deserialize the list from JSON
    public void DeserializeFromJson(string filePath)
    {
        if (File.Exists(filePath) )
        {
            string jsonData = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<T>>(jsonData);
        }
    }
}
