namespace TicTacToe.View;

public interface IInputObservable<out T>
{
    void Subscribe(IInputObserver<T> inputObserver);

    void Unsubscribe(IInputObserver<T> inputObserver);
}