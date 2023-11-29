using ChessConsole.Enums;
using ChessConsole.Exceptions;
using ChessConsole.Pieces;

namespace ChessConsole.Tests;

[TestClass]
public class TestMove
{
    private readonly Game  _game = new ();
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

    [TestInitialize]
    public void Initialize()
    {
        _game.Pieces = _testPosition;
    }
    
    private bool IsMoveValid(Coordinates cordFrom, Coordinates cordTo)
    {
        var piece = _game.Pieces[cordFrom];
        
        var action = _game.Move(cordFrom, cordTo);

        return action == piece;
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
    [ExpectedException(typeof(InvalidMoveException))]
    public void TestInvalidPawnMove()
    {
        var cordFrom = new Coordinates(0, Rank.F);
        var cordTo = new Coordinates(0, Rank.G);

        IsMoveValid(cordFrom, cordTo);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidMoveException))]
    public void TestInvalidKingMove()
    {
        var cordFrom = new Coordinates(0, Rank.A);
        var cordTo = new Coordinates(3, Rank.A);

        IsMoveValid(cordFrom, cordTo);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidMoveException))]
    public void TestInvalidQueenMove()
    {
        var cordFrom = new Coordinates(0, Rank.B);
        var cordTo = new Coordinates(5, Rank.D);

        IsMoveValid(cordFrom, cordTo);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidMoveException))]
    public void TestInvalidRookMove()
    {
        var cordFrom = new Coordinates(0, Rank.C);
        var cordTo = new Coordinates(6, Rank.B);

        IsMoveValid(cordFrom, cordTo);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidMoveException))]
    public void TestInvalidBishopMove()
    {
        var cordFrom = new Coordinates(0, Rank.D);
        var cordTo = new Coordinates(3, Rank.H);

        IsMoveValid(cordFrom, cordTo);
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidMoveException))]
    public void TestInvalidKnightMove()
    {
        var cordFrom = new Coordinates(0, Rank.E);
        var cordTo = new Coordinates(4, Rank.D);

        IsMoveValid(cordFrom, cordTo);
    }
}