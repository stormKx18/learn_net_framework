public class UserInput
{
    static void GreetUser(){
        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Hello " + name + "!");
    }
    public static void Main(string[] args)
    {
        GreetUser();
    }
}