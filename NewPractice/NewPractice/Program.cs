using System.Security.Cryptography;

class Program 
{
    class C 
    {
        public int Value = 0;
    }
    static void Main(string[] args)
    {
        int v1 = 0;
        int v2 = v1;
        v2 = 927;
        C r1 = new C();
        C r2 = r1;
        r2.Value = 112;
        Console.WriteLine("Calues:{0},{1}", v1, v2);
        Console.WriteLine("Refs:{0},{1}",r1.Value, r2.Value);
        Console.ReadLine();
    }
}
