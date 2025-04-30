// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Contracts;
using ApexBattle.Request;
using TheQuantumThief;

Console.WriteLine("Hello, World!");

var Penny = new Penhaligan();


var Request = new PennyKindleJob();

var Response = Penny.Recruit(Request);



ConsoleKeyInfo KeyPress;
do
{
    KeyPress = Console.ReadKey();

} while (KeyPress.Key != ConsoleKey.Escape);






