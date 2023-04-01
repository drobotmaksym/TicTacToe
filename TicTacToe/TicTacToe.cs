using TicTacToe.Model.Board;
using TicTacToe.View;

namespace TicTacToe;

public sealed class TicTacToe
{
    internal static GameLoop GameLoop;

    static TicTacToe()
    {
        GameLoop = new GameLoop(null, null);
    }
    
    public static void Main(string[] args)
    {
        Board board = new(3);
        BoardView boardView = new(board);
        boardView.RenderAndDelegateToChildren();
    }
}