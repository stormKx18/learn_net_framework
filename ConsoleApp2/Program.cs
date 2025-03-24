// See https://aka.ms/new-console-template for more information

public class Calculator
{
    public static int number1;
    public static int number2;

    public static int Add(int number1, int number2)
    {
        return number1 + number2;
    }

    public static int Subtract(int number1, int number2)
    {
        return number1 - number2;
    }

    static void Main(string[] args)
    {
        number1 = 10;
        number2 = 5;

        Console.WriteLine("Addition: " + Add(number1, number2));
        Console.WriteLine("Subtraction: " + Subtract(number1, number2));
    }
}
