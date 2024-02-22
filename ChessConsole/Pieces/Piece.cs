using ChessConsole.Enums;
using ChessConsole.Extensions;

namespace ChessConsole.Pieces;

public abstract class Piece(Color color, Coordinates coordinates)
{
    public Color Color { get; } = color;
    public Coordinates Coordinates { get; set; } = coordinates;
    
    public abstract bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo);
    
    public bool TryTake(Coordinates cordFrom, Coordinates cordTo)
    {
        if (Game.Pieces[cordTo].Color != Game.Pieces[cordFrom].Color)
        {
            Game.Pieces.Remove(cordTo);
            Game.Pieces.ChangeKey(cordFrom, cordTo);
            return true;
        }

        return false;
    }}