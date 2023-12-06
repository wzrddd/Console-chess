using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Rook(Color color, Coordinates coordinates) : IPiece 
{
    public Color Color { get; } = color;
    public Coordinates Coordinates { get; set; } = coordinates;
    
    public override string ToString()
    {
        return Color == Color.White ? "R" : "r";
    }
    
    public bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        return cordFrom.Rank == cordTo.Rank || cordFrom.File == cordTo.File;
    }
}