using TicTacToe.Model;
using TicTacToe.Model.Event;

namespace TicTacToe.View;

public abstract class ObservableView<T> : View, IInputObservable<T>
{
    private readonly List<IInputObserver<T>> _observers = new();
    
    public T Model { get; }

    protected ObservableView(T model)
    {
        Model = model;
    }

    private void DelegateKeyPressHandleToObservers(KeyPressEvent keyPressEvent)
    {
        foreach (var observer in _observers)
        {
            observer.HandleKeyPress(Model, keyPressEvent);
        }
    }

    private View? GetChildDelegateIfAny(Position position)
    {
        foreach (View child in Children)
        {
            if (child.Rectangle.Contains(position)) return child;
        }

        return null;
    }

    public override void OnKeyPress(KeyPressEvent keyPressEvent)
    {
        View? childDelegate = GetChildDelegateIfAny(keyPressEvent.Position);
        if (childDelegate == null)
        {
            DelegateKeyPressHandleToObservers(keyPressEvent);
        }
        else
        {
            childDelegate.OnKeyPress(keyPressEvent);
        }
    }
    
    public abstract override void Render();
    
    public void Subscribe(IInputObserver<T> inputObserver)
    {
        _observers.Add(inputObserver);
    }

    public void Unsubscribe(IInputObserver<T> inputObserver)
    {
        _observers.Remove(inputObserver);
    }
}