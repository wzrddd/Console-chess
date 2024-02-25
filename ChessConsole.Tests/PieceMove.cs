using ChessConsole.Enums;
using ChessConsole.Pieces;

namespace ChessConsole.Tests;

public class PieceMove
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
        
        {new Coordinates(6, Rank.A), new King(Color.Black, new Coordinates(0, Rank.A))},
        {new Coordinates(6, Rank.B), new Queen(Color.Black, new Coordinates(0, Rank.B))},
        {new Coordinates(6, Rank.C), new Rook(Color.Black, new Coordinates(0, Rank.C))},
        {new Coordinates(6, Rank.D), new Bishop(Color.Black, new Coordinates(0, Rank.D))},
        {new Coordinates(6, Rank.E), new Knight(Color.Black, new Coordinates(0, Rank.E))},
        {new Coordinates(6, Rank.F), new Pawn(Color.Black, new Coordinates(0, Rank.F))},
    };
    
    public class CoordinatesTestCase(Coordinates cordFrom, Coordinates cordTo, bool result, string testName)
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
    
    private static IEnumerable<CoordinatesTestCase> CoordinatesTestCases
    {
        get
        {
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.F),
                new Coordinates(1, Rank.F), 
                true, 
                "TestValidPawnMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.F),
                new Coordinates(4, Rank.F), 
                false,
                "TestInvalidPawnMove");

            yield return new CoordinatesTestCase(
                new Coordinates(7, Rank.F),
                new Coordinates(5, Rank.F),
                false,
                "TestBlockPawnMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.E),
                new Coordinates(2, Rank.F), 
                true,
                "TestValidKnightMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.E),
                new Coordinates(4, Rank.D), 
                false,
                "TestInvalidKnightMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(7, Rank.E),
                new Coordinates(5, Rank.F),
                true,
                "TestBlockKnightMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.D),
                new Coordinates(4, Rank.H), 
                true,
                "TestValidBishopMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.D),
                new Coordinates(3, Rank.H), 
                false,
                "TestInvalidBishopMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(7, Rank.D),
                new Coordinates(5, Rank.B),
                false,
                "TestBlockBishopMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.C),
                new Coordinates(5, Rank.C), 
                true,
                "TestValidRookMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.C),
                new Coordinates(5, Rank.B), 
                false,
                "TestInvalidRookMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(7, Rank.C),
                new Coordinates(5, Rank.C),
                false,
                "TestBlockRookMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.B),
                new Coordinates(3, Rank.E), 
                true,
                "TestValidQueenMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.B),
                new Coordinates(5, Rank.D), 
                false,
                "TestInvalidQueenMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(7, Rank.B),
                new Coordinates(5, Rank.B),
                false,
                "TestBlockQueenMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.A),
                new Coordinates(1, Rank.A), 
                true,
                "TestValidKingMove");
            
            yield return new CoordinatesTestCase(
                new Coordinates(0, Rank.A),
                new Coordinates(3, Rank.A),
                false,
                "TestInvalidKingMove");
        }
    }
    
    [SetUp]
    public void Setup()
    {
        Game.Pieces = _testPosition;
    }

    [Test, TestCaseSource(nameof(CoordinatesTestCases))]
    public void TestMove(CoordinatesTestCase coordinatesTestCase)
    {
        var piece = Game.Pieces[coordinatesTestCase.CordFrom];
        var isMoveValid = piece.IsMoveValid(coordinatesTestCase.CordFrom, coordinatesTestCase.CordTo);
        
        Assert.That(isMoveValid, Is.EqualTo(coordinatesTestCase.Result));
    }
}