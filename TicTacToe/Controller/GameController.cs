using TicTacToe.Model.Dash;
using TicTacToe.Model.Evaluation;
using TicTacToe.Model.Event;
using TicTacToe.Model.Game;
using TicTacToe.View;

namespace TicTacToe.Controller;

public class GameController : IInputObserver<BoardView>
{
    private Game _game;
    private Dash _dash;
    
    public void OnKeyPress(BoardView boardView, KeyPressEvent keyPressEvent)
    {
        Evaluation evaluation = BoardEvaluator.EvaluateAndGenerateDash(boardView.Model);
        HandleGameState(evaluation.GameState, evaluation.Dash);
    }

    private void HandleGameState(GameState gameState, Dash? dash)
    {
        switch (gameState)
        {
            case GameState.Win:
                ArgumentNullException.ThrowIfNull(dash);
                _game.Statistics.IncreaseWinsFor(_game.CurrentPlayer);
                _game.Stop();
                _dash = dash;
                break;
            case GameState.Tie:
                _game.Statistics.IncreaseTies();
                _game.Stop();
                break;
            case GameState.Intermediate:
                _game.SwitchPlayer();
                break;
        }
    }
}