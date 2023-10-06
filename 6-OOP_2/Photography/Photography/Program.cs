using System;

namespace Photography;
class Program
{
    static void Main()
    {
        Lens fisheye = new(100, 1001);
        Lens standard = new(100, 1002);
        Lens shortrange = new(100, 1003);

        Camera CameraS = new("Sony", 155, 1010, true, fisheye);
        Camera CameraT = new("Toshiba", 158, 1100, false, standard);
        Camera CameraWD = new("Western Digital", 159, 101, true, shortrange);

        CameraS.SetBrand("Eastern Digital");

        Console.WriteLine("Setted CameraS to EasternDigital");
        Console.WriteLine(CameraS.ToString());

        Console.WriteLine("\nIts Brand:");
        CameraS.GetBrand();

        Console.WriteLine("\n1\n"+ fisheye.ToString());

        Console.WriteLine("\n2\n"+ CameraT.ToString()+ "\n\n");

        Console.WriteLine("3 "+CameraWD.ToString());

        CameraT.GetDisplaySize();
    }
}