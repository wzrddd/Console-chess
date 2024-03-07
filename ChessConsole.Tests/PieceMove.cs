using ChessConsole.Enums;
using ChessConsole.Pieces;

namespace ChessConsole.Tests;

public class PieceMove
{
    private readonly Dictionary<Coordinates, Piece> _testPosition = new ()
    {
        {new Coordinates(0, Rank.A), new King(Color.White)},
        {new Coordinates(0, Rank.B), new Queen(Color.White)},
        {new Coordinates(0, Rank.C), new Rook(Color.White)},
        {new Coordinates(0, Rank.D), new Bishop(Color.White)},
        {new Coordinates(0, Rank.E), new Knight(Color.White)},
        {new Coordinates(4, Rank.F), new Pawn(Color.White)},

        {new Coordinates(7, Rank.A), new King(Color.Black)},
        {new Coordinates(7, Rank.B), new Queen(Color.Black)},
        {new Coordinates(7, Rank.C), new Rook(Color.Black)},
        {new Coordinates(7, Rank.D), new Bishop(Color.Black)},
        {new Coordinates(7, Rank.E), new Knight(Color.Black)},
        {new Coordinates(7, Rank.F), new Pawn(Color.Black)},

        {new Coordinates(6, Rank.A), new King(Color.Black)},
        {new Coordinates(6, Rank.B), new Queen(Color.Black)},
        {new Coordinates(6, Rank.C), new Rook(Color.Black)},
        {new Coordinates(6, Rank.D), new Bishop(Color.Black)},
        {new Coordinates(6, Rank.E), new Knight(Color.Black)},
        {new Coordinates(6, Rank.F), new Pawn(Color.Black)}
    };
    
    private static IEnumerable<PieceTestCase> PieceValidMoveTestCases
    {
        get
        {
            yield return new PieceTestCase(
                new Coordinates(4, Rank.F),
                new Coordinates(5, Rank.F), 
                true, 
                "TestValidPawnMove");
            
            yield return new PieceTestCase(
                new Coordinates(4, Rank.F),
                new Coordinates(6, Rank.F), 
                true, 
                "TestValidPawnMove");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.E),
                new Coordinates(2, Rank.F), 
                true,
                "TestValidKnightMove");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.D),
                new Coordinates(4, Rank.H), 
                true,
                "TestValidBishopMove");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.C),
                new Coordinates(5, Rank.C), 
                true,
                "TestValidRookMove");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.B),
                new Coordinates(3, Rank.E), 
                true,
                "TestValidQueenMove");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.A),
                new Coordinates(1, Rank.A), 
                true,
                "TestValidKingMove");
        }
    }

    private static IEnumerable<PieceTestCase> PieceInvalidMoveTestCases
    {
        get
        {
            yield return new PieceTestCase(
                new Coordinates(4, Rank.F),
                new Coordinates(3, Rank.F), 
                false,
                "TestInvalidPawnMove");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.E),
                new Coordinates(4, Rank.D), 
                false,
                "TestInvalidKnightMove");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.D),
                new Coordinates(3, Rank.H), 
                false,
                "TestInvalidBishopMove");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.C),
                new Coordinates(5, Rank.B), 
                false,
                "TestInvalidRookMove");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.B),
                new Coordinates(5, Rank.D), 
                false,
                "TestInvalidQueenMove");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.A),
                new Coordinates(3, Rank.A),
                false,
                "TestInvalidKingMove");
        }
    }

    private static IEnumerable<PieceTestCase> PieceBlockedMoveTestCases
    {
        get
        {
            yield return new PieceTestCase(
                new Coordinates(7, Rank.F),
                new Coordinates(5, Rank.F),
                false,
                "TestBlockPawnMove");
            
            
            yield return new PieceTestCase(
                new Coordinates(7, Rank.E),
                new Coordinates(5, Rank.F),
                true,
                "TestBlockKnightMove");
            
            
            yield return new PieceTestCase(
                new Coordinates(7, Rank.D),
                new Coordinates(5, Rank.B),
                false,
                "TestBlockBishopMove");
            
            yield return new PieceTestCase(
                new Coordinates(7, Rank.C),
                new Coordinates(5, Rank.C),
                false,
                "TestBlockRookMove");
            
            yield return new PieceTestCase(
                new Coordinates(7, Rank.B),
                new Coordinates(5, Rank.B),
                false,
                "TestBlockQueenMove");
        }
    }

    [SetUp]
    public void Setup()
    {
        Game.Pieces = _testPosition;
    }

    [Test, TestCaseSource(nameof(PieceValidMoveTestCases))]
    public void TestValidMove(PieceTestCase coordinatesTestCase)
    {
        var piece = Game.Pieces[coordinatesTestCase.CordFrom];
        var isMoveValid = piece.IsMoveValid(coordinatesTestCase.CordFrom, coordinatesTestCase.CordTo);
        
        Assert.That(isMoveValid, Is.EqualTo(coordinatesTestCase.Result));
    }
    
    [Test, TestCaseSource(nameof(PieceInvalidMoveTestCases))]
    public void TestInvalidMove(PieceTestCase coordinatesTestCase)
    {
        var piece = Game.Pieces[coordinatesTestCase.CordFrom];
        var isMoveValid = piece.IsMoveValid(coordinatesTestCase.CordFrom, coordinatesTestCase.CordTo);
        
        Assert.That(isMoveValid, Is.EqualTo(coordinatesTestCase.Result));
    }
    
    [Test, TestCaseSource(nameof(PieceBlockedMoveTestCases))]
    public void TestBlockedMove(PieceTestCase coordinatesTestCase)
    {
        var piece = Game.Pieces[coordinatesTestCase.CordFrom];
        var isMoveValid = piece.IsMoveValid(coordinatesTestCase.CordFrom, coordinatesTestCase.CordTo);
        
        Assert.That(isMoveValid, Is.EqualTo(coordinatesTestCase.Result));
    }
}