using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class King(Color color) : Piece(color)
{
    public bool IsFirstMove = true;

    public override string ToString()
    {
        return Color == Color.White ? "K" : "k";
    }

    public override bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var xDiff = Math.Abs((int)cordFrom.Rank - (int)cordTo.Rank);
        var yDiff = Math.Abs(cordFrom.File - cordTo.File);
        var isMoveCorrect = xDiff <= 1 && yDiff <= 1;

        if (Game.Pieces[cordTo] is Rook rook && IsFirstMove && rook.Color == color && rook.IsFirstMove)
        {
            Castle(cordFrom, cordTo);
            return true;
        }
        
        if (Game.Pieces.ContainsKey(cordTo) && isMoveCorrect)
        {
            return TryTake(cordFrom, cordTo);
        }
        
        return isMoveCorrect;
    }

    private void Castle(Coordinates cordFrom, Coordinates cordTo)
    {
        var pieceCordFrom = Game.Pieces[cordFrom];
        var pieceCordTo = Game.Pieces[cordTo];
        
        Game.Pieces.Remove(cordTo);
        Game.Pieces.Remove(cordFrom);

        if (cordTo.Rank == Rank.A)
        {
            Game.Pieces.Add(new Coordinates(cordFrom.File, Rank.C), pieceCordFrom);
            Game.Pieces.Add(new Coordinates(cordTo.File, Rank.D), pieceCordTo);
        }
        else
        {
            Game.Pieces.Add(new Coordinates(cordFrom.File, Rank.G), pieceCordFrom);
            Game.Pieces.Add(new Coordinates(cordTo.File, Rank.F), pieceCordTo);
        }
    }

    protected override void RemovePiece(Coordinates coordinates)
    {
        Game.IsGameOver = true;
        base.RemovePiece(coordinates);
    }
}