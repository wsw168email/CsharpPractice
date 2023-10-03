class MyClass1
{
    private int x = 0;
    private int y = 0;
    public int X
    {
        get 
        {
            return x;
        }
        set 
        {
            x = value;
        }
    }
    public int Y 
    {
        get 
        {
            return y;
        }
        set
        { 
            y = value;
        }
    }
    public virtual int Add()
    {
        return X + Y;
    }
}
class MyClass2 : MyClass1
{
    public override int Add()
    {
        int x = 5;
        int y = 7;
        return x + y;
    }
}
class Program
{
    static void Main(string[] args)
    { 
        MyClass2 myclass2 = new MyClass2();
        MyClass1 myclass1 = new MyClass1();
        myclass1.X = 3;
        myclass1.Y = 5;
        Console.WriteLine(myclass2.Add());
        Console.WriteLine(myclass1.Add());

    }
}