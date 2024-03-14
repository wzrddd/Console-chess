using ChessConsole.Enums;
using ChessConsole.Extensions;

namespace ChessConsole.Pieces;

public abstract class Piece(Color color)
{
    public Color Color { get; } = color;
    
    public abstract bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo);

    protected virtual void RemovePiece(Coordinates coordinates)
    {
        Game.Pieces.Remove(coordinates);
    }
        
    public bool TryTake(Coordinates cordFrom, Coordinates cordTo)
    {
        if (Game.Pieces[cordTo].Color != Game.Pieces[cordFrom].Color) 
        {
            Game.Pieces[cordTo].RemovePiece(cordTo);
            Game.Pieces.ChangeKey(cordFrom, cordTo);
            return true;
        }

        return false;
    }
}