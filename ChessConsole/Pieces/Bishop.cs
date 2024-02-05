using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Bishop(Color color, Coordinates coordinates) : IPiece
{
    public Color Color { get; } = color;
    public Coordinates Coordinates { get; set; } = coordinates;

    public override string ToString()
    {
        return Color == Color.White ? "B" : "b";
    }

    public bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var yMin = Math.Min(cordFrom.File, cordTo.File); 
        var xMin = Math.Min((int)cordFrom.Rank, (int)cordTo.Rank);
        var xMax = Math.Max((int)cordFrom.Rank, (int)cordTo.Rank);
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);

        if (xDiff != yDiff)
            return false;
        
        var j = yMin + 1;
        for (int i = xMin + 1; i < xMax; i++)
        {
            if (Game.Pieces.ContainsKey(new Coordinates(j, (Rank)i)))
            {
                return false;
            }
            j++;
        }

        return true;
    }
}