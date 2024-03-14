using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Rook(Color color) : Piece(color) 
{
    public override string ToString()
    {
        return Color == Color.White ? "R" : "r";
    }
    
    public override bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
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