using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Bishop(Color color) : Piece(color)
{
    public override string ToString()
    {
        return Color == Color.White ? "\u2657" : "\u265d";
    }

    public override bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        return CommonMoves.CheckDiagonal(cordFrom, cordTo);
    }
}