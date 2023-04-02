using TicTacToe.Model.Event;

namespace TicTacToe.View;

public interface IKeyListener
{
    void PressKey(KeyPressEvent keyPressEvent);
}