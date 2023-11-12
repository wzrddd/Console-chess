using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Pawn : Piece
{
    public Pawn(Color color, Coordinates coordinates) : base(color, coordinates) {}

    public override string ToString()
    {
        return Color == Color.White ? "P" : "p";
    }

    public override void Move(Coordinates coordinates)
    {
        throw new NotImplementedException();
    }
}