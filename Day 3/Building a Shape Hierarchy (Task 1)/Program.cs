using System;

namespace ShapeHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {   
            Circle circle = new Circle{ Name = "Circle", Radius = 2 };

            Rectangle rectangle = new Rectangle{ Name = "Rectangle", Height = 5, Width = 10 };

            Triangle triangle = new Triangle{ Name = "Triangle", Base = 5, Height = 10 };

            printShapeArea(circle);
            printShapeArea(rectangle);
            printShapeArea(triangle);
            
        }

        static void printShapeArea (Shape shape)
        {
            Console.WriteLine($"The area of the {shape.Name} is {shape.calculateArea()}");
        }
    }

    public class Shape
    {
        public string Name { get; set; }

        public virtual double calculateArea()
        {
            return 0;
            // throw new NotImplementedException("The CalculateArea() method is not implemented for the base Shape class.");
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double calculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override double calculateArea()
        {
            return Height * Width;
        }
    }

    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public override double calculateArea()
        {
            return (Base * Height) / 2;
        }
    }

}