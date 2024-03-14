using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public static class CommonMoves
{
    public static bool CheckVertical(Coordinates cordFrom, Coordinates cordTo)
    {
        var piece = Game.Pieces[cordFrom];
        var min = Math.Min(cordFrom.File, cordTo.File);
        var max = Math.Max(cordFrom.File, cordTo.File);
        
        for (var i = min + 1; i < max; i++)
        {
            if (Game.Pieces.ContainsKey(new Coordinates(i, cordFrom.Rank)))
            {
                return false;
            }
        }

        if (Game.Pieces.ContainsKey(cordTo))
        {
            return piece.TryTake(cordFrom, cordTo);
        }
        
        return true;
    }

    public static bool CheckHorizontal(Coordinates cordFrom, Coordinates cordTo)
    {
        var piece = Game.Pieces[cordFrom];
        var min = Math.Min((int)cordFrom.Rank, (int)cordTo.Rank);
        var max = Math.Max((int)cordFrom.Rank, (int)cordTo.Rank);
        
        for (var i = min + 1; i < max; i++)
        {
            if (Game.Pieces.ContainsKey(new Coordinates(cordFrom.File, (Rank)i)))
            {
                return false;
            }
        }
        
        if (Game.Pieces.ContainsKey(cordTo))
        {
            return piece.TryTake(cordFrom, cordTo);
        }
        
        return true;

    }

    public static bool CheckDiagonal(Coordinates cordFrom, Coordinates cordTo)
    {
        var xDirection = cordFrom.Rank < cordTo.Rank ? 1 : -1;
        var yDirection = cordFrom.File < cordTo.File ? 1 : -1;
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);
        var piece = Game.Pieces[cordFrom];


        if (xDiff != yDiff)
            return false;

        var cords = cordFrom;
        while (cords.Rank != cordTo.Rank - 1 && cords.File != cordTo.File - 1)
        {
            cords.Rank += xDirection;
            cords.File += yDirection;
            if (Game.Pieces.ContainsKey(cords))
            {
                return false;
            }
        }

        if (Game.Pieces.ContainsKey(cordTo))
        {
            return piece.TryTake(cordFrom, cordTo);
        }

        return true;

    }
}