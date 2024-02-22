using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Pawn(Color color, Coordinates coordinates) : Piece(color, coordinates)
{
    public override string ToString()
    {
        return Color == Color.White ? "P" : "p";
    }

    public override bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);
        var isMoveCorrect = xDiff == 0 && yDiff == 1;
        
        if (Game.Pieces.ContainsKey(cordTo) && isMoveCorrect)
        {
            return TryTake(cordFrom, cordTo);
        }
        
        return isMoveCorrect;
    }
}