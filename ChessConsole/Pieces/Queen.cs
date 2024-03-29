using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Queen(Color color) : Piece(color)
{
    public override string ToString()
    {
        return Color == Color.White ? "\u2655" : "\u265b";
    }

    public override bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);

        if (xDiff == yDiff)
        {
            return CommonMoves.CheckDiagonal(cordFrom, cordTo);
        }        
        
        if (cordFrom.Rank == cordTo.Rank)
        {
            return CommonMoves.CheckVertical(cordFrom, cordTo);
        }
        
        if (cordFrom.File == cordTo.File)
        {
            return CommonMoves.CheckHorizontal(cordFrom, cordTo);
        }
        
        return false;
    }
}