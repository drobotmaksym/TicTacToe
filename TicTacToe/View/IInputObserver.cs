namespace TicTacToe.View;

public interface IInputObserver<in T> : IKeyHandler<T> 
{
    // Should be no own methods
}