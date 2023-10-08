using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Shapes;

public abstract class Shape
{
    public string Color { get; set; }
    public bool IsFilled { get; set; }

    public Shape(string color, bool isFilled)
    {
        Color = color;
        IsFilled = isFilled;
    }

    public abstract double GetArea();
    public abstract double GetPerimeter();
}


public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(string color, bool isFilled, double radius) : base(color, isFilled)
    {
        if (radius <= 0)
            throw new ArgumentException("\nERROR: Radius must be higher than 0.\n");
        else 
            Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(string color, bool isFilled, double width, double height) : base(color, isFilled)
    {
        if (width <= 0)
            throw new ArgumentException("\nERROR: Width must be higher than 0.\n");
        else if (height <= 0)
            throw new ArgumentException("\nHeight must be higher than 0.\n");
        else
        {
            Width = width;
            Height = height;
        }
        
    }

    public override double GetArea()
    {
        return Width * Height;
    }

    public override double GetPerimeter()
    {
        return 2 * (Width + Height);
    }
}

public class Square : Rectangle
{
    public double Side { get; set; }

    public Square(string color, bool isFilled, double side) : base(color, isFilled, side, side)
    {
        if (side <= 0)
            throw new ArgumentException("Side length must be higher than 0.");
        else 
            Side = side;
    }

    public override double GetArea()
    {
        return Side * Side;
    }

    public override double GetPerimeter()
    {
        return 4 * Side;
    }
}
