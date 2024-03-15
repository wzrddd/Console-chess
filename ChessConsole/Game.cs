using ChessConsole.Enums;
using ChessConsole.Extensions;
using ChessConsole.Pieces;

namespace ChessConsole;

public static class Game
{
    private static Color _turn = Color.White;

    public static bool IsGameOver = false;
    public static Dictionary<Coordinates, Piece> Pieces = new()
    {
        {new Coordinates(0, Rank.A), new Rook(Color.White)},
        {new Coordinates(0, Rank.B), new Knight(Color.White)},
        {new Coordinates(0, Rank.C), new Bishop(Color.White)},
        {new Coordinates(0, Rank.D), new Queen(Color.White)},
        {new Coordinates(0, Rank.E), new King(Color.White)},
        {new Coordinates(0, Rank.F), new Bishop(Color.White)},
        {new Coordinates(0, Rank.G), new Knight(Color.White)},
        {new Coordinates(0, Rank.H), new Rook(Color.White)},
        {new Coordinates(7, Rank.A), new Rook(Color.Black)},
        {new Coordinates(7, Rank.B), new Knight(Color.Black)},
        {new Coordinates(7, Rank.C), new Bishop(Color.Black)},
        {new Coordinates(7, Rank.D), new Queen(Color.Black)},
        {new Coordinates(7, Rank.E), new King(Color.Black)},
        {new Coordinates(7, Rank.F), new Bishop(Color.Black)},
        {new Coordinates(7, Rank.G), new Knight(Color.Black)},
        {new Coordinates(7, Rank.H), new Rook(Color.Black)}
    };
    
    static Game()
    {
        for (int i = 0; i < 8; i++)
        {
            Pieces.Add(new Coordinates(1, (Rank)i), new Pawn(Color.White));
            Pieces.Add(new Coordinates(6, (Rank)i), new Pawn(Color.Black));
        }
    }

    public static void Render()
    {
        for (int i = 7; i >= 0; i--)
        {
            for (int j = 0; j < 8; j++)
            {
                if (j == 0) Console.Write($"({i + 1})");

                if (Pieces.ContainsKey(new Coordinates(i, (Rank)j)))
                    Console.Write($"[{Pieces[new Coordinates(i, (Rank)j)]}]");
                else if(!Pieces.ContainsKey(new Coordinates(i, (Rank)j)))
                    Console.Write("[ ]");
            }
            Console.WriteLine();
        }
        Console.WriteLine("   (A)(B)(C)(D)(E)(F)(G)(H)");
    }

    public static bool Move(Coordinates cordFrom, Coordinates cordTo)
    {
        var pieceToMove = Pieces[cordFrom];
        
        if (pieceToMove.IsMoveValid(cordFrom, cordTo) && pieceToMove.Color == _turn)
        {
            Pieces.ChangeKey(cordFrom, cordTo);
            _turn = _turn == Color.White ? Color.Black : Color.White;
            
            return true;
        }
        
        return false;
    }

    public static void Loop()
    {
        Console.WriteLine($"{_turn} turn!");
        Console.Write("Pick piece: ");
        var mFrom = Console.ReadLine()!.ToCharArray();
        Console.Write("Move to: ");
        var mTo = Console.ReadLine()!.ToCharArray();
            
        var cordFrom = new Coordinates(mFrom[1] - '0' - 1, (Rank)Enum.Parse(typeof(Rank), mFrom[0].ToString().ToUpper()));
        var cordTo = new Coordinates(mTo[1] - '0' - 1, (Rank)Enum.Parse(typeof(Rank), mTo[0].ToString().ToUpper()));
        var move = Move(cordFrom, cordTo);

        if (move)
        {
            Console.Clear();
            Render();
        }
        else
            Console.WriteLine("Move is not valid");
    }
}