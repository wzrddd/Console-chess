using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Knight(Color color) : Piece(color)
{
    public override string ToString()
    {
        return Color == Color.White ? "N" : "n";
    }

    public override bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);
        var isMoveCorrect = ((xDiff == 2 && yDiff == 2) || (xDiff == 1 && yDiff == 2));
        
        if (Game.Pieces.ContainsKey(cordTo) && isMoveCorrect)
        {
            return TryTake(cordFrom, cordTo);
        }
        
        return isMoveCorrect;
    }
}