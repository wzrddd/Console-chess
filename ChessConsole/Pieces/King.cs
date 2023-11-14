using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class King(Color color, Coordinates coordinates) : Piece(color, coordinates)
{
    public override string ToString()
    {
        return Color == Color.White ? "K" : "k";
    }
    
    public override void Move(Coordinates coordinates)
    {
        throw new NotImplementedException();
    }
}