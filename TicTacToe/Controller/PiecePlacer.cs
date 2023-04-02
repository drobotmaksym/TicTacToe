using TicTacToe.Model.Event;
using TicTacToe.Model.Game;
using TicTacToe.View;

namespace TicTacToe.Controller;

public class PiecePlacer : IInputObserver<BoxView>
{
    private Game _game;
    
    public void OnKeyPress(BoxView boxView, KeyPressEvent keyPressEvent)
    {
        if (keyPressEvent.KeyInfo.Key != ConsoleKey.Enter) return;
        if (_game.GameState == GameState.Stopped) return;
        boxView.Model.Piece = _game.CurrentPlayer.Piece;
    }
}