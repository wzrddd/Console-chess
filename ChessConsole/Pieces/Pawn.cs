using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Pawn(Color color, Coordinates coordinates) : Piece(color, coordinates)
{
    public override string ToString()
    {
        return Color == Color.White ? "P" : "p";
    }
}