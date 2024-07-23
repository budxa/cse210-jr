using System;
using Learning05;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square= new Square("Red",6);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Green",8 ,4);
        shapes.Add(rectangle);
        
        Circle circle = new Circle("Blue", 7);
        shapes.Add(circle);
        
        foreach(Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The color {color} shape has the area of {area}.");
        }
        
    }
}