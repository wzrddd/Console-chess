using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Pawn(Color color) : Piece(color)
{
    public override string ToString()
    {
        return Color == Color.White ? "P" : "p";
    }

    public override bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var piece = Game.Pieces[cordFrom];
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        
        var isMoveCorrect = piece.Color == Color.White
            ? cordTo.File - cordFrom.File == 1
            : cordFrom.File - cordTo.File == 1;
        
        if (Game.Pieces.ContainsKey(cordTo) && isMoveCorrect && xDiff == 1)
            return TryTake(cordFrom, cordTo);
        
        return isMoveCorrect;
    }
}