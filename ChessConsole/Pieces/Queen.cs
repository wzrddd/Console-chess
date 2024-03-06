using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Queen(Color color) : Piece(color)
{
    public override string ToString()
    {
        return Color == Color.White ? "Q" : "q";
    }

    public override bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);
        var isMoveCorrect = xDiff == yDiff || cordFrom.Rank == cordTo.Rank || cordFrom.File == cordTo.File;

        if (xDiff == yDiff)
        {
            var yMin = Math.Min(cordFrom.File, cordTo.File);
            var xMin = Math.Min((int)cordFrom.Rank, (int)cordTo.Rank);
            var xMax = Math.Max((int)cordFrom.Rank, (int)cordTo.Rank);
            
            var j = yMin + 1;
            for (int i = xMin + 1; i < xMax; i++)
            {
                if (Game.Pieces.ContainsKey(new Coordinates(j, (Rank)i)))
                {
                    return false;
                }
                j++;
            }
        }        
        
        if (cordFrom.Rank == cordTo.Rank)
        {
            var min = Math.Min(cordFrom.File, cordTo.File);
            var max = Math.Max(cordFrom.File, cordTo.File);
            for (var i = min + 1; i < max; i++)
            {
                if (Game.Pieces.ContainsKey(new Coordinates(i, cordFrom.Rank)))
                {
                    return false;
                }
            }
        }
        
        if (cordFrom.File == cordTo.File)
        {
            var min = Math.Min((int)cordFrom.Rank, (int)cordTo.Rank);
            var max = Math.Max((int)cordFrom.Rank, (int)cordTo.Rank);
            for (var i = min + 1; i < max; i++)
            {
                if (Game.Pieces.ContainsKey(new Coordinates(cordFrom.File, (Rank)i)))
                {
                    return false;
                }
            }
        }
        
        if (Game.Pieces.ContainsKey(cordTo) && isMoveCorrect)
        {
            return TryTake(cordFrom, cordTo);
        }
        
        return isMoveCorrect;
    }
}