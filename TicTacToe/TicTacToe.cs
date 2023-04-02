using TicTacToe.Model.Board;
using TicTacToe.Model.Dash;
using TicTacToe.Model.Evaluation;
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

    }
}