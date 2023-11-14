using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public abstract class Piece(Color color, Coordinates coordinates)
{
    public Color Color = color;
    public Coordinates Coordinates = coordinates;

    public abstract void Move(Coordinates coordinates);
}