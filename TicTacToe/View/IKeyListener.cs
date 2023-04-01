using TicTacToe.Model.Event;

namespace TicTacToe.View;

public interface IClickListener
{
    void OnKeyPress(KeyPressEvent keyPressEvent);
}