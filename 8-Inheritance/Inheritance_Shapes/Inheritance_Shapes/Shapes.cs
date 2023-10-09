using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Shapes;

public abstract class Shape
{
    public string Color;
    public bool IsFilled;

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
    public double Radius;

    public Circle(string color, bool isFilled, double radius) : base(color, isFilled)
    {
        if (radius <= 0)
            throw new ArgumentException("\nERROR: Radius must be greater than 0.\n");
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
    internal double width;
    public virtual double Width { 
        get { return width; }
        set {

            if (value <= 0)
                throw new ArgumentException("\nERROR: Width must be greater than 0.\n");
            width = value;
        }
    }
    internal double height; /*protected if i want to use it in another package*/
    public virtual double Height
    {
        get { return  height; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("\nERROR: Height must be greater than 0.\n");
            height = value;
        }
    }

    public Rectangle(string color, bool isFilled, double width, double height) : base(color, isFilled)
    {
        Width = width;
        Height = height;
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
    public override double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("\nERROR: Side must be greater than 0.\n");
            width = value;
        }
    }
    public override double Height
    {
        get { return height; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("\nERROR: Side must be greater than 0.\n");
            height = value;
        }
    }

    public Square(string color, bool isFilled, double side) : base(color, isFilled, side, side)
    {
    }

}



/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Shapes;

public abstract class Shape
{
    public string Color;
    public bool IsFilled;

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
    public double Radius;

    public Circle(string color, bool isFilled, double radius) : base(color, isFilled)
    {
        if (radius <= 0)
            throw new ArgumentException("\nERROR: Radius must be greater than 0.\n");
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
    private double width;
    private double height;
   
    public Rectangle(string color, bool isFilled, double width, double height) : base(color, isFilled)
    {
        SetWidth(width);
        SetHeight(height);
    }

    public override double GetArea()
    {
        return width * height;
    }

    public override double GetPerimeter()
    {
        return 2 * (width + height);
    }

    public double GetHeight()
    {
        return height;
    }

    public double GetWidth()
    {
        return width;
    }

    public virtual void SetWidth(double width)
    {
        if (width <= 0)
                throw new ArgumentException("\nERROR: Width must be greater than 0.\n");
        this.width = width;
    }

    public virtual void SetHeight(double height)
    {
        if (height <= 0)
            throw new ArgumentException("\nERROR: Height must be greater than 0.\n");
        this.height = height;
    }
}

public class Square : Rectangle
{
    public Square(string color, bool isFilled, double side) : base(color, isFilled, side, side)
    {
    }

    public override void SetWidth(double width)
    {
        if (width <= 0)
            throw new ArgumentException("\nERROR: Side must be greater than 0.\n");
        base.SetWidth(width);
    }

    public override void SetHeight(double height)
    {
        if (height <= 0)
            throw new ArgumentException("\nERROR: Side must be greater than 0.\n");
        base.SetHeight(height);
    }
}
*/