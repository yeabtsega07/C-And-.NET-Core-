using System;

namespace ShapeHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {   

            // Create a Shape class with a Name property and a virtual method called CalculateArea() that returns a double.
            Circle circle = new Circle{ Name = "Circle", Radius = 2 };

            // Create a Circle class that inherits from Shape and has a Radius property.
            Rectangle rectangle = new Rectangle{ Name = "Rectangle", Height = 5, Width = 10 };

            // Create a Rectangle class that inherits from Shape and has Height and Width properties.
            Triangle triangle = new Triangle{ Name = "Triangle", Base = 5, Height = 10 };


            // Create a Triangle class that inherits from Shape and has Base and Height properties.
            printShapeArea(circle);
            printShapeArea(rectangle);
            printShapeArea(triangle);
            
        }

        // Create a method that accepts a Shape object and prints the area of the shape to the console.
        static void printShapeArea (Shape shape)
        {
            Console.WriteLine($"The area of the {shape.Name} is {shape.calculateArea()}");
        }
    }

    // Create a Shape class with a Name property and a virtual method called CalculateArea() that returns a double.
    public class Shape
    {
        public string Name { get; set; }

        // Create a method that accepts a Shape object and prints the area of the shape to the console.
        public virtual double calculateArea()
        {
            return 0;
            // throw new NotImplementedException("The CalculateArea() method is not implemented for the base Shape class.");
        }
    }
    
    // Create a Circle class that inherits from Shape and has a Radius property.
    public class Circle : Shape
    {
        public double Radius { get; set; }

        // Override the CalculateArea() method on the Circle class to return the correct area of a circle.
        public override double calculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    // Create a Rectangle class that inherits from Shape and has Height and Width properties.
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        // Override the CalculateArea() method on the Rectangle class to return the correct area of a rectangle.
        public override double calculateArea()
        {
            return Height * Width;
        }
    }
    
    // Create a Triangle class that inherits from Shape and has Base and Height properties.
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        
        // Override the CalculateArea() method on the Triangle class to return the correct area of a triangle.
        public override double calculateArea()
        {
            return (Base * Height) / 2;
        }
    }

}