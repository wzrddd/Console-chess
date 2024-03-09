using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Bishop(Color color) : Piece(color)
{
    public override string ToString()
    {
        return Color == Color.White ? "B" : "b";
    }

    public override bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var xDirection = cordFrom.Rank < cordTo.Rank ? 1 : -1;
        var yDirection = cordFrom.File < cordTo.File ? 1 : -1;
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);

        if (xDiff != yDiff)
            return false;

        var cords = cordFrom;
        while (cords.Rank != cordTo.Rank && cords.File != cordTo.File)
        {
            cords.Rank += xDirection;
            cords.File += yDirection;
            if (Game.Pieces.ContainsKey(cords))
            {
                return false;
            }
        }

        if (Game.Pieces.ContainsKey(cordTo))
        {
            return TryTake(cordFrom, cordTo);
        }

        return true;
    }
}