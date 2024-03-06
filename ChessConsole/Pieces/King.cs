using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class King(Color color) : Piece(color)
{
    public override string ToString()
    {
        return Color == Color.White ? "K" : "k";
    }

    public override bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);
        var isMoveCorrect = xDiff <= 1 && yDiff <= 1;

        if (Game.Pieces.ContainsKey(cordTo) && isMoveCorrect)
        {
            return TryTake(cordFrom, cordTo);
        }
        
        return isMoveCorrect;
    }
}