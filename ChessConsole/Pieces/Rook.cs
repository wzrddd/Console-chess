using ChessConsole.Enums;

namespace ChessConsole.Pieces;

public class Rook(Color color, Coordinates coordinates) : IPiece 
{
    public Color Color { get; } = color;
    public Coordinates Coordinates { get; set; } = coordinates;
    
    public override string ToString()
    {
        return Color == Color.White ? "R" : "r";
    }
    
    public bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        if (cordFrom.Rank == cordTo.Rank)
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
            return true;
        }
        
        if (cordFrom.File == cordTo.File)
        {
            var min = Math.Min((int)cordFrom.Rank, (int)cordTo.Rank);
            var max = Math.Max((int)cordFrom.Rank, (int)cordTo.Rank);
            for (var i = min + 1; i < max; i++)
            {
                if (Game.Pieces.ContainsKey(new Coordinates(cordFrom.File, (Rank)i)))
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}