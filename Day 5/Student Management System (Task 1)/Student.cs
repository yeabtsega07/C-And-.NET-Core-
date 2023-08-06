// Student.cs
using System;

public class Student
{
    public string Name { get; }
    public int Age { get; }
    public int RollNumber { get; }
    public string Grade { get; }

    public Student(string name, int age, int rollNumber, string grade)
    {
        Name = name;
        Age = age;
        RollNumber = rollNumber;
        Grade = grade;
    }
}
