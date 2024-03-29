using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Rook(Color color) : Piece(color) 
{
    public bool IsFirstMove = true;

    public override string ToString()
    {
        return Color == Color.White ? "\u2656" : "\u265c";
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