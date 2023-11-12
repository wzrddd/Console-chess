using ChessConsole.Enums;
using ChessConsole.Pieces;

namespace ChessConsole;

public class Game
{
    public Dictionary<Coordinates, Piece> Pieces = new()
    {
        {new Coordinates(0, Rank.A), new Pawn(Color.White, new Coordinates(0, Rank.A))},
        {new Coordinates(7, Rank.H), new Pawn(Color.Black, new Coordinates(9, Rank.H))}
    };

    public void Render()
    {
        Console.WriteLine("   (#1)(#2)(#3)(#4)(#5)(#6)(#7)(#8)");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (j == 0) Console.Write("(" + (Rank)i + ")");

                if (Pieces.ContainsKey(new Coordinates(j, (Rank)i)))
                    Console.Write($"[{Pieces[new Coordinates(j, (Rank)i)]}]");
                else if(!Pieces.ContainsKey(new Coordinates(j, (Rank)i)))
                    Console.Write("[ ]");
            }
            Console.WriteLine();
        }
    }
}