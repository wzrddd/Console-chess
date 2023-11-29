using ChessConsole.Enums;
using ChessConsole.Pieces;

namespace ChessConsole;

public class Game
{
    public Dictionary<Coordinates, Piece> Pieces = new()
    {
        {new Coordinates(0, Rank.A), new Rook(Color.White, new Coordinates(0, Rank.A))},
        {new Coordinates(0, Rank.B), new Knight(Color.White, new Coordinates(0, Rank.B))},
        {new Coordinates(0, Rank.C), new Bishop(Color.White, new Coordinates(0, Rank.C))},
        {new Coordinates(0, Rank.D), new Queen(Color.White, new Coordinates(0, Rank.D))},
        {new Coordinates(0, Rank.E), new King(Color.White, new Coordinates(0, Rank.E))},
        {new Coordinates(0, Rank.F), new Bishop(Color.White, new Coordinates(0, Rank.F))},
        {new Coordinates(0, Rank.G), new Knight(Color.White, new Coordinates(0, Rank.G))},
        {new Coordinates(0, Rank.H), new Rook(Color.White, new Coordinates(0, Rank.H))},
        {new Coordinates(7, Rank.A), new Rook(Color.Black, new Coordinates(7, Rank.A))},
        {new Coordinates(7, Rank.B), new Knight(Color.Black, new Coordinates(7, Rank.B))},
        {new Coordinates(7, Rank.C), new Bishop(Color.Black, new Coordinates(7, Rank.C))},
        {new Coordinates(7, Rank.D), new Queen(Color.Black, new Coordinates(7, Rank.D))},
        {new Coordinates(7, Rank.E), new King(Color.Black, new Coordinates(7, Rank.E))},
        {new Coordinates(7, Rank.F), new Bishop(Color.Black, new Coordinates(7, Rank.F))},
        {new Coordinates(7, Rank.G), new Knight(Color.Black, new Coordinates(7, Rank.G))},
        {new Coordinates(7, Rank.H), new Rook(Color.Black, new Coordinates(7, Rank.H))}
    };
    
    public Game()
    {
        for (int i = 0; i < 8; i++)
        {
            Pieces.Add(new Coordinates(1, (Rank)i), new Pawn(Color.White, new Coordinates(1, (Rank)i)));
            Pieces.Add(new Coordinates(6, (Rank)i), new Pawn(Color.Black, new Coordinates(6, (Rank)i)));
        }
    }

    public void Render()
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

    public Piece Move(Coordinates fCord, Coordinates tCord)
    {
        var pieceToMove = Pieces[fCord];
        Pieces.Remove(fCord);
        pieceToMove.Coordinates = tCord;
        Pieces.Add(tCord, pieceToMove);
        return pieceToMove;
    }
}