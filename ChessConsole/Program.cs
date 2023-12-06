using ChessConsole.Enums;

namespace ChessConsole; 

using System;

internal class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        var game = new Game();
        game.Render();
        
        while (true)
        {
            Console.Write("pick piece: ");
            var mFrom = Console.ReadLine()!.ToCharArray();
            Console.Write("move to: ");
            var mTo = Console.ReadLine()!.ToCharArray();
            
            var cordFrom = new Coordinates(mFrom[1] - '0' - 1, (Rank)Enum.Parse(typeof(Rank), mFrom[0].ToString().ToUpper()));
            var cordTo = new Coordinates(mTo[1] - '0' - 1, (Rank)Enum.Parse(typeof(Rank), mTo[0].ToString().ToUpper()));
            var move = game.Move(cordFrom, cordTo);

            if (move != null)
            {
                Console.Clear();
                game.Render();
            }
            else
            {
                Console.WriteLine("Move is not valid");
            }
        }
    }
}