using ChessConsole.Enums;

namespace ChessConsole; 

using System;

internal class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Game.Render();
        
        while (true)
        {
            Game.Loop();
        }
    }
}