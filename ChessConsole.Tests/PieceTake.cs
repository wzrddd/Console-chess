using ChessConsole.Enums;
using ChessConsole.Pieces;

namespace ChessConsole.Tests;

public class PieceTake
{
    private readonly Dictionary<Coordinates, Piece> _testPosition = new ()
    {
        {new Coordinates(0, Rank.A), new King(Color.White, new Coordinates(0, Rank.A))},
        {new Coordinates(0, Rank.B), new Queen(Color.White, new Coordinates(0, Rank.B))},
        {new Coordinates(0, Rank.C), new Rook(Color.White, new Coordinates(0, Rank.C))},
        {new Coordinates(0, Rank.D), new Bishop(Color.White, new Coordinates(0, Rank.D))},
        {new Coordinates(0, Rank.E), new Knight(Color.White, new Coordinates(0, Rank.E))},
        {new Coordinates(0, Rank.F), new Pawn(Color.White, new Coordinates(0, Rank.F))},
            
            
        {new Coordinates(7, Rank.A), new King(Color.Black, new Coordinates(0, Rank.A))},
        {new Coordinates(7, Rank.B), new Queen(Color.Black, new Coordinates(0, Rank.B))},
        {new Coordinates(7, Rank.C), new Rook(Color.Black, new Coordinates(0, Rank.C))},
        {new Coordinates(7, Rank.D), new Bishop(Color.Black, new Coordinates(0, Rank.D))},
        {new Coordinates(7, Rank.E), new Knight(Color.Black, new Coordinates(0, Rank.E))},
        {new Coordinates(7, Rank.F), new Pawn(Color.Black, new Coordinates(0, Rank.F))},
    };

    private static IEnumerable<PieceTestCase> PieceTakeEnemyTestCases
    {
        get
        {
            yield return new PieceTestCase(
                new Coordinates(0, Rank.F),
                new Coordinates(1, Rank.F), 
                true, 
                "TestValidPawnMove");
        }
    }

    [SetUp]
    public void Setup()
    {
        Game.Pieces = _testPosition;
    }

    [Test, TestCaseSource(nameof(PieceTakeEnemyTestCases))]
    public void TestMove(PieceTestCase coordinatesTestCase)
    {
        var piece = Game.Pieces[coordinatesTestCase.CordFrom];
        var isMoveValid = piece.IsMoveValid(coordinatesTestCase.CordFrom, coordinatesTestCase.CordTo);
        
        Assert.That(isMoveValid, Is.EqualTo(coordinatesTestCase.Result));
    }
}