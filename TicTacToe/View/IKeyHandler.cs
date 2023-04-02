using TicTacToe.Model.Event;

namespace TicTacToe.View;

public interface IKeyHandler<in T>
{
    void OnKeyPress(T model, KeyPressEvent keyPressEvent);
}