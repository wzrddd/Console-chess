using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public abstract class Piece
{
    public Color Color;
    public Coordinates Coordinates;

    protected Piece(Color color, Coordinates coordinates)
    {
        Color = color;
        Coordinates = coordinates;
    }

    public abstract void Move(Coordinates coordinates);
}