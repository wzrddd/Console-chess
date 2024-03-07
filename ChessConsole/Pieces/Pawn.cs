using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Pawn(Color color) : Piece(color)
{
    private bool IsFirstMove = true;
    
    public override string ToString()
    {
        return Color == Color.White ? "P" : "p";
    }

    public override bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var piece = Game.Pieces[cordFrom];
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);
        
        var isMoveCorrect = piece.Color == Color.White
            ? cordTo.File - cordFrom.File == 1
            : cordFrom.File - cordTo.File == 1;

        if (IsFirstMove)
        { 
            var min = Math.Min(cordFrom.File, cordTo.File);
            var max = Math.Max(cordFrom.File, cordTo.File);
            for (var i = min + 1; i < max; i++)
            {
                if (Game.Pieces.ContainsKey(new Coordinates(i, cordFrom.Rank)))
                {
                    return false;
                }
            }

            isMoveCorrect = piece.Color == Color.White
                ? cordTo.File - cordFrom.File == 2 || cordTo.File - cordFrom.File == 1
                : cordFrom.File - cordTo.File == 2 || cordFrom.File - cordTo.File == 1;

            IsFirstMove = false;
        }
        
        if (Game.Pieces.ContainsKey(cordTo) && isMoveCorrect && xDiff == 1 && yDiff == 1)
            return TryTake(cordFrom, cordTo);
        
        return isMoveCorrect;
    }
}