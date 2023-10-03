// See https://aka.ms/new-console-template for more information
// Declare cariables and then initialize to zero
double num1 = 0;
double num2 = 0;
double choice = 0;

// Display title as the C# console calculator app.
Console.WriteLine("Console Calculator in C#\r");
Console.WriteLine("------------------------\r");

// Ask the user to type the first number.
Console.WriteLine("Type a number, and then press Enter\r");
num1 = Convert.ToDouble(Console.ReadLine());

//Ask the user to type the second number.
Console.WriteLine("Type another number, and then press Enter\r");
num2 = Convert.ToDouble(Console.ReadLine());

//Ask the user to choose an option.
Console.WriteLine("Choose an option from the following list:");
Console.WriteLine("\ta - Add");
Console.WriteLine("\ts - Subtract");
Console.WriteLine("\tm - Multiply");
Console.WriteLine("\td - Divide");
Console.Write("Your option? ");

// Use a switch statement to do the math.
while (choice == 0) 
{
    switch (Console.ReadLine())
    {
        case "a":
            Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
            choice = 1;
            break;
        case "s":
            Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
            choice = 1;
            break;
        case "m":
            Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
            choice = 1;
            break;
        case "d":
            // Ask the user to enter a non-zero divisor until they do so.
            while (num2 == 0)
            {
                Console.WriteLine("Enter a non-zero divisor: ");
                num2 = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
            break;
        default:
            Console.WriteLine("You enter the wrong option");
            break;
    }
}

// Wait for the user to respond before closing.
Console.Write("Press any key to close the Calculator console app...");
Console.ReadKey();