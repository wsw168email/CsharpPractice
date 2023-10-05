// See https://aka.ms/new-console-template for more informationu

using CoordinateTransformLibrary;
//4250.5589,S,        42度50"33.534'
//14718.5084, E       147度18"30.504'
class Program 
{   
    static void Main(string[] args)
    {
        string result = "";
        result = CoordinateTransform.lonlat_To_twd97(147, 18, 30.504,42, 50, 33.534);
        Console.WriteLine(result);
        Console.ReadLine();
    }
}

