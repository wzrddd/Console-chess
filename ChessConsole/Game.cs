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

    private static bool Move(Coordinates cordFrom, Coordinates cordTo)
    {
        var pieceToMove = Pieces[cordFrom];
        
        if (pieceToMove.IsMoveValid(cordFrom, cordTo) && pieceToMove.Color == _turn)
        {
            Pieces.ChangeKey(cordFrom, cordTo);
            _turn = _turn == Color.White ? Color.Black : Color.White;
            
            if (cordTo.File is 0 or 7 && pieceToMove is Pawn pawnToMove)
            {
                Console.WriteLine("Pick piece to promote(Q, N, B, R)");
                Console.Write("> ");
                var promotion = Console.ReadLine();
                if (promotion != null) pawnToMove.ProcessPromotion(cordTo, promotion.ToLower());
            }

            return true;
        }
        
        return false;
    }

    public static void Loop()
    {
        Console.WriteLine($"{_turn} turn!");
        Console.Write("> ");
        var move = Console.ReadLine()?.Split(' ');
        bool isMoveValid;
        
        if (move == null)
        {
            Console.WriteLine("Move is not valid");
            return;
        }

        try
        {
            var cordFrom = new Coordinates(move[0][1] - '0' - 1, (Rank)Enum.Parse(typeof(Rank), move[0][0].ToString().ToUpper()));
            var cordTo = new Coordinates(move[1][1] - '0' - 1, (Rank)Enum.Parse(typeof(Rank), move[1][0].ToString().ToUpper()));
            isMoveValid = Move(cordFrom, cordTo);
        }
        catch (Exception)
        {
            Console.WriteLine("Move is not valid");
            return;
        }
        
        if (isMoveValid)
        {
            Console.Clear();
            Render();
        }
        else
            Console.WriteLine("Move is not valid");
    }
}