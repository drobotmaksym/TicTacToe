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
        rootComponent.AddChild(boardComponent);
        
        GameLoop = new GameLoop(rootComponent);
        GameLoop.Start();
    }
}