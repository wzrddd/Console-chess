using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Queen(Color color, Coordinates coordinates) : Piece(color, coordinates)
{
    public override string ToString()
    {
        return Color == Color.White ? "Q" : "q";
    }
}