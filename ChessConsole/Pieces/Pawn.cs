using System.Security.Cryptography;
using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Pawn(Color color) : Piece(color)
{
    private bool _isFirstMove = true;
    private bool _isCanPromoted = false;
    
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

        if (_isFirstMove)
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

            _isFirstMove = false;
        }
        
        if (Game.Pieces.ContainsKey(cordTo) && isMoveCorrect && xDiff == 1 && yDiff == 1)
            return TryTake(cordFrom, cordTo);
        
        return isMoveCorrect;
    }

    public void ProcessPromotion(Coordinates coordinates, string piece)
    {
        var pawn = Game.Pieces[coordinates];
        
        // TODO: find way how to improve this part (i don't like it, but i don't know how to do it better)
        switch (piece)
        {
            case "q":
                Game.Pieces.Remove(coordinates);
                Game.Pieces.Add(coordinates, new Queen(pawn.Color));
                break;
            case "n":
                Game.Pieces.Remove(coordinates);
                Game.Pieces.Add(coordinates, new Knight(pawn.Color));
                break;
            case "b":
                Game.Pieces.Remove(coordinates);
                Game.Pieces.Add(coordinates, new Bishop(pawn.Color));
                break;
            case "r":
                Game.Pieces.Remove(coordinates);
                Game.Pieces.Add(coordinates, new Rook(pawn.Color));
                break;
        }
    }
}