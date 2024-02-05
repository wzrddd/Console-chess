using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Knight(Color color, Coordinates coordinates) : IPiece
{
    public Color Color { get; } = color;
    public Coordinates Coordinates { get; set; } = coordinates;
    
    public override string ToString()
    {
        return Color == Color.White ? "N" : "n";
    }

    public bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);
        return ((xDiff == 2 && yDiff == 2) || (xDiff == 1 && yDiff == 2)) && !Game.Pieces.ContainsKey(cordTo);
    }
}