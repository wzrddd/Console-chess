using ChessConsole.Enums;
using ChessConsole.Pieces;

namespace ChessConsole.Tests;

public class PieceTake
{
    private readonly Dictionary<Coordinates, Piece> _testPosition = new ()
    {
        {new Coordinates(0, Rank.A), new King(Color.White)},
        {new Coordinates(0, Rank.B), new Queen(Color.White)},
        {new Coordinates(0, Rank.C), new Rook(Color.White)},
        {new Coordinates(0, Rank.D), new Bishop(Color.White)},
        {new Coordinates(0, Rank.E), new Knight(Color.White)},
        {new Coordinates(0, Rank.F), new Pawn(Color.White)},

        {new Coordinates(1, Rank.G), new Pawn(Color.Black)},
        {new Coordinates(2, Rank.F), new Pawn(Color.Black)},
        {new Coordinates(3, Rank.A), new Pawn(Color.Black)},
        {new Coordinates(4, Rank.C), new Pawn(Color.Black)},
        {new Coordinates(3, Rank.E), new Pawn(Color.Black)},
        {new Coordinates(1, Rank.A), new Pawn(Color.Black)},
        
        {new Coordinates(7, Rank.F), new Pawn(Color.Black)},
        {new Coordinates(6, Rank.E), new Pawn(Color.White)},
        {new Coordinates(5, Rank.E), new Pawn(Color.Black)},
        {new Coordinates(5, Rank.C), new Pawn(Color.White)},
        {new Coordinates(4, Rank.D), new Pawn(Color.Black)},
    };

    private static IEnumerable<PieceTestCase> PieceTakeEnemyValidTestCases
    {
        get
        {
            yield return new PieceTestCase(
                new Coordinates(0, Rank.F),
                new Coordinates(1, Rank.G), 
                true, 
                "PawnTakeValid");
            
            yield return new PieceTestCase(
                new Coordinates(7, Rank.F),
                new Coordinates(6, Rank.E), 
                true, 
                "PawnTakeBlackValid");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.E),
                new Coordinates(2, Rank.F), 
                true, 
                "KnightTakeValid"); 
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.D),
                new Coordinates(3, Rank.A), 
                true, 
                "BishopTakeValid");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.C),
                new Coordinates(4, Rank.C), 
                true, 
                "RookTakeValid");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.B),
                new Coordinates(3, Rank.E), 
                true, 
                "QueenTakeValid");
            
            yield return new PieceTestCase(
                new Coordinates(0, Rank.A),
                new Coordinates(1, Rank.A), 
                true, 
                "KingTakeValid");
        }
    }

    private static IEnumerable<PieceTestCase> PieceTakeInvalidTestCases
    {
        get
        {
            yield return new PieceTestCase(
                new Coordinates(3, Rank.E),
                new Coordinates(2, Rank.F), 
                false, 
                "TryToTakeAlly");
            
            yield return new PieceTestCase(
                new Coordinates(5, Rank.E),
                new Coordinates(6, Rank.F), 
                false, 
                "PawnTakeInvalid");
            
            yield return new PieceTestCase(
                new Coordinates(5, Rank.C),
                new Coordinates(4, Rank.D), 
                false, 
                "PawnWhiteTakeInvalid");
        }
    }

    [SetUp]
    public void Setup()
    {
        Game.Pieces = _testPosition;
    }

    [Test, TestCaseSource(nameof(PieceTakeEnemyValidTestCases))]
    public void TakeEnemyValid(PieceTestCase coordinatesTestCase)
    {
        var piece = Game.Pieces[coordinatesTestCase.CordFrom];
        var isMoveValid = piece.IsMoveValid(coordinatesTestCase.CordFrom, coordinatesTestCase.CordTo);
        
        Assert.That(isMoveValid, Is.EqualTo(coordinatesTestCase.Result));
    }
    
    [Test, TestCaseSource(nameof(PieceTakeInvalidTestCases))]
    public void TakeInvalid(PieceTestCase coordinatesTestCase)
    {
        var piece = Game.Pieces[coordinatesTestCase.CordFrom];
        var isMoveValid = piece.IsMoveValid(coordinatesTestCase.CordFrom, coordinatesTestCase.CordTo);
        
        Assert.That(isMoveValid, Is.EqualTo(coordinatesTestCase.Result));
    }
}