// See https://aka.ms/new-console-template for more information
using System.Drawing;
using Pastel;

Console.WriteLine("Hello, World!".Pastel(Color.Yellow));

bool isTrue = true;
bool isFalse = false;

Console.WriteLine(isTrue);
Console.WriteLine(isFalse);


if (isTrue && !isFalse)
{
    Console.WriteLine("isTrue && !isFalse");
}

