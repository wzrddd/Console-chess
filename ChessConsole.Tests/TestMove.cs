using ChessConsole.Enums;
using ChessConsole.Pieces;

namespace ChessConsole.Tests;

[TestClass]
public class TestMove
{
    private readonly Dictionary<Coordinates, IPiece> _testPosition = new ()
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

    [TestInitialize]
    public void Initialize()
    {
        Game.Pieces = _testPosition;
    }
    
    private bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var piece = Game.Pieces[cordFrom];
        
        return piece.IsMoveValid(cordFrom, cordTo);
    }
    
    [TestMethod]
    public void TestValidPawnMove()
    {
        var cordFrom = new Coordinates(0, Rank.F);
        var cordTo = new Coordinates(1, Rank.F);
        
        Assert.IsTrue(IsMoveValid(cordFrom, cordTo));
    }

    [TestMethod]
    public void TestValidKingMove()
    {
        var cordFrom = new Coordinates(0, Rank.A);
        var cordTo = new Coordinates(1, Rank.A);
        
        Assert.IsTrue(IsMoveValid(cordFrom, cordTo));
    }
    
    [TestMethod]
    public void TestValidQueenMove()
    {
        var cordFrom = new Coordinates(0, Rank.B);
        var cordTo = new Coordinates(3, Rank.E);
        
        Assert.IsTrue(IsMoveValid(cordFrom, cordTo));
    }
    
    [TestMethod]
    public void TestValidRookMove()
    {
        var cordFrom = new Coordinates(0, Rank.C);
        var cordTo = new Coordinates(5, Rank.C);
        
        Assert.IsTrue(IsMoveValid(cordFrom, cordTo)); 
    }
    
    [TestMethod]
    public void TestValidBishopMove()
    {
        var cordFrom = new Coordinates(0, Rank.D);
        var cordTo = new Coordinates(4, Rank.H);
        
        Assert.IsTrue(IsMoveValid(cordFrom, cordTo));
    }
    
    [TestMethod]
    public void TestValidKnightMove()
    {
        var cordFrom = new Coordinates(0, Rank.E);
        var cordTo = new Coordinates(2, Rank.F);
        
        Assert.IsTrue(IsMoveValid(cordFrom, cordTo));
    }
    
    [TestMethod]
    public void TestInvalidPawnMove()
    {
        var cordFrom = new Coordinates(0, Rank.F);
        var cordTo = new Coordinates(0, Rank.G);

        Assert.IsFalse(IsMoveValid(cordFrom, cordTo));
    }
    
    [TestMethod]
    public void TestInvalidKingMove()
    {
        var cordFrom = new Coordinates(0, Rank.A);
        var cordTo = new Coordinates(3, Rank.A);

        Assert.IsFalse(IsMoveValid(cordFrom, cordTo));
    }
    
    [TestMethod]
    public void TestInvalidQueenMove()
    {
        var cordFrom = new Coordinates(0, Rank.B);
        var cordTo = new Coordinates(5, Rank.D);

        Assert.IsFalse(IsMoveValid(cordFrom, cordTo));
    }
    
    [TestMethod]
    public void TestInvalidRookMove()
    {
        var cordFrom = new Coordinates(0, Rank.C);
        var cordTo = new Coordinates(6, Rank.B);

        Assert.IsFalse(IsMoveValid(cordFrom, cordTo));
    }
    
    [TestMethod]
    public void TestInvalidBishopMove()
    {
        var cordFrom = new Coordinates(0, Rank.D);
        var cordTo = new Coordinates(3, Rank.H);

        Assert.IsFalse(IsMoveValid(cordFrom, cordTo));
    }
    
    [TestMethod]
    public void TestInvalidKnightMove()
    {
        var cordFrom = new Coordinates(0, Rank.E);
        var cordTo = new Coordinates(4, Rank.D);

        Assert.IsFalse(IsMoveValid(cordFrom, cordTo));
    }
}