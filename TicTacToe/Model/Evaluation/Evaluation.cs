using TicTacToe.Model.Game;

namespace TicTacToe.Model.Evaluation;

public class Evaluation
{
    public GameState GameState { get; }

    public Evaluation(GameState gameState)
    {
        GameState = gameState;
    }
}