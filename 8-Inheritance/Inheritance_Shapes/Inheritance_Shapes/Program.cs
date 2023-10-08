namespace Inheritance_Shapes;

class Program
{
    static void Main()
    {
        Shape circle = new Circle("Green", true, 5.0);
        Shape rectangle = new Rectangle("White", false, 4, 6);
        Shape square = new Square("Red", true, 11.0);

        Console.WriteLine($"Circle Area: {circle.GetArea()}, Perimeter: {circle.GetPerimeter()}\nit's {circle.Color} colored\nis it filled? Answer: {circle.IsFilled}\n");
        Console.WriteLine($"\nRectangle Area: {rectangle.GetArea()}, Perimeter: {rectangle.GetPerimeter()}\nit's {rectangle.Color} colored\nis it filled? Answer: {rectangle.IsFilled}\n");
        Console.WriteLine($"Square Area: {square.GetArea()}, Perimeter: {square.GetPerimeter()}\nit's {square.Color} colored\nis it filled? Answer: {square.IsFilled}");
    }
}
