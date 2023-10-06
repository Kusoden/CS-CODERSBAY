using Photography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Photography
{
    public class Camera
    {
        string brand;
        int MP;
        double displaySize;
        bool colored;
        private readonly Lens lens;

        public Camera(string brand, int megaPixels, double displaySize, bool colored, Lens lens)
        {
            this.brand = brand;
            this.MP = megaPixels;
            this.displaySize = displaySize;
            this.colored = colored;
            this.lens = lens;
        }

        public Camera()
        {
        }

        public string GetBrand()
        {
            Console.WriteLine(brand);
            return brand;
        }

        public void SetBrand(string brand)
        {
            if (brand == null)
                Console.WriteLine("Type a Brand Name");
            else
                this.brand = brand;
        }

        public int GetMP()
        {
            Console.WriteLine(MP);
            return MP;
        }

        public void SetMP(int megaPixels)
        {
            if (megaPixels <= 0)
                Console.WriteLine("it must be a Higher number for Mega Pixels");
            else
                this.MP = megaPixels;
        }

        public double GetDisplaySize()
        {
            Console.WriteLine(displaySize);
            return displaySize;
        }

        public void SetDisplaySize(double displaySize)
        {
            if (displaySize <= 0)
                Console.WriteLine("Die Displaygröße muss größer sein");
            else
                this.displaySize = displaySize;
        }
        public bool IsColored()
        {
            return colored;
        }

        public void SetColored(bool colored)
        {
            this.colored = colored;
        }

        public Lens GetLens()
        {
            Console.WriteLine(lens);
            return lens;
        }

        public override string ToString() => "Camera brand: " + brand + "  Mega Pixels: " + MP + "  displaySize: " + displaySize + "  colored: " + colored + "  lens: " + lens;
    }
}