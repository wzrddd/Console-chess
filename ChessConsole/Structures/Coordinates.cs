using ChessConsole.Enums;

namespace ChessConsole;

public struct Coordinates
{
    public Coordinates(int file, Rank rank)
    {
        File = file;
        Rank = rank;
    }
    
    public int File;
    public Rank Rank;
}