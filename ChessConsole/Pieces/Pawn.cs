using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Pawn(Color color, Coordinates coordinates) : IPiece
{
    public Color Color { get; } = color;
    public Coordinates Coordinates { get; set; } = coordinates;
    
    public override string ToString()
    {
        return Color == Color.White ? "P" : "p";
    }

    public bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        throw new NotImplementedException();
    }
}