using TicTacToe.Model.Game;

namespace TicTacToe.Model.Evaluation;

public class Evaluation
{
    public GameState GameState { get; }
    
    public Dash.Dash? Dash { get; }

    public Evaluation(GameState gameState, Dash.Dash? dash = null)
    {
        GameState = gameState;
        Dash = dash;
    }
}