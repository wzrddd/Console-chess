using ChessConsole.Enums;
using ChessConsole.Pieces;

namespace ChessConsole;

public class Game
{
    public Dictionary<Coordinates, Piece> Pieces = new()
    {
        {new Coordinates(0, Rank.A), new Pawn(Color.White, new Coordinates(0, Rank.A))},
        {new Coordinates(9, Rank.H), new Pawn(Color.Black, new Coordinates(9, Rank.H))}
    };

    public void Render()
    {
        Console.WriteLine("\u2655");
    }
}