using TicTacToe.Model.Dash;
using TicTacToe.Model.Game;

namespace TicTacToe.Model.Evaluation;

public class Evaluation
{
    public GameState GameState { get; }
    
    public DashInfo? DashInfo { get; }

    public Evaluation(GameState gameState, DashInfo? dashInfo = null)
    {
        GameState = gameState;
        DashInfo = dashInfo;
    }
}