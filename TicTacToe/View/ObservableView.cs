using TicTacToe.Model;
using TicTacToe.Model.Event;

namespace TicTacToe.View;

public abstract class ObservableView<T> : View, IInputObservable<T>
{
    private readonly List<IInputObserver<T>> _observers = new();
    
    public T Model { get; }
    
    public Position Position { get; set; }
    
    public Dimension Dimension { get; set; }

    protected ObservableView(T model)
    {
        Model = model;
    }
    
    public override void OnKeyPress(KeyPressEvent keyPressEvent)
    {
        foreach (var observer in _observers)
        {
            observer.HandleKeyPress(Model, keyPressEvent);
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