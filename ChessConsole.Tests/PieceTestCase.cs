namespace ChessConsole.Tests;

public class PieceTestCase(Coordinates cordFrom, Coordinates cordTo, bool result, string testName)
{
    public string TestName { get; private set; } = testName;
    public Coordinates CordFrom { get; set; } = cordFrom;
    public Coordinates CordTo { get; set; } = cordTo;
    public bool Result { get; set; } = result;

    public override string ToString()
    {
        return TestName;
    }
}