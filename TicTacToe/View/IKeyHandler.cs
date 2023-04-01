using TicTacToe.Model.Event;

namespace TicTacToe.View;

public interface IKeyHandler<in T>
{
    void HandleKeyPress(T source, KeyPressEvent keyPressEvent);
}