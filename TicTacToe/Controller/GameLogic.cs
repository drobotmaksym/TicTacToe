using TicTacToe.Model;
using TicTacToe.Model.Board;
using TicTacToe.Model.Game;

namespace TicTacToe.Controller;

public class GameLogic
{
    private readonly Game _game;

    public GameLogic(Game game)
    {
        _game = game;
    }

    public void OnBoxPress(Box box)
    {
        if (box.Piece == Box.Empty)
        {
            PlacePiece(box);
            SwitchGameState(BoardEvaluator.EvaluateAndGenerateDash(_game.GameBoard));
            return;
        }

        if (_game.GameState != GameState.Intermediate) _game.Restart();
    }

    private void PlacePiece(Box box)
    {
        box.Piece = _game.CurrentPlayer.Piece;
    }

    private void SwitchGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Win:
                _game.Statistics.IncreaseWinsFor(_game.CurrentPlayer);
                _game.Stop();
                break;
            case GameState.Tie:
                _game.Statistics.IncreaseTies();
                _game.Stop();
                break;
            case GameState.Intermediate:
                _game.SwitchPlayer();
                break;
        }

        _game.GameState = gameState;
    }
}