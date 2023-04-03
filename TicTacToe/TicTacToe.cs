using TicTacToe.Controller;
using TicTacToe.Model;
using TicTacToe.Model.Board;
using TicTacToe.View;

namespace TicTacToe;

public sealed class TicTacToe
{
    internal static GameLoop GameLoop;

    public static void Main(string[] args)
    {
        GameBoard board = new(3);
        
        BoardComponent boardComponent = new(board);
        
        Component rootComponent = new RootComponent();
        rootComponent.Dimension = new Dimension(25, 25);
        rootComponent.AddChild(boardComponent);

        Position boardPosition = new Position(2, 2);
        Console.SetCursorPosition(boardPosition.X, boardPosition.Y);
        boardComponent.Dimension = new Dimension(board.Size, board.Size);
        boardComponent.Position = boardPosition;

        GameLoop = new GameLoop(rootComponent);
        GameLoop.Start();
    }
}