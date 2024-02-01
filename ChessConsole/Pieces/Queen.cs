using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Queen(Color color, Coordinates coordinates) : IPiece
{
    public Color Color { get; } = color;
    public Coordinates Coordinates { get; set; } = coordinates;
    
    public override string ToString()
    {
        return Color == Color.White ? "Q" : "q";
    }

    public bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);
        return xDiff == yDiff ||  xDiff <= 1 && yDiff <= 1 || cordFrom.Rank == cordTo.Rank || cordFrom.File == cordTo.File;
    }
}