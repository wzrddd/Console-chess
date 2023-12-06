using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public interface IPiece
{
    public Color Color { get; }
    public Coordinates Coordinates { get; set; }
    
    bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo);
}