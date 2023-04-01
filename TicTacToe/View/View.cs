using TicTacToe.Model;
using TicTacToe.Model.Event;

namespace TicTacToe.View;

public abstract class View<T> : View, IInputObservable<T>
{
    private readonly List<IInputObserver<T>> _observers = new();
    
    public T Model { get; }
    
    public Position Position { get; set; }
    
    public Dimension Dimension { get; set; }

    protected View(T model)
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

public abstract class View : IRenderable, IClickListener
{
    private readonly List<View> _children = new();
    public IEnumerable<View> Children => _children;
    public Position Position { get; set; }
    public Dimension Dimension { get; set; }

    public abstract void OnKeyPress(KeyPressEvent keyPressEvent);

    public abstract void Render();

    public void RenderAndDelegateToChildren()
    {
        Render();
        foreach (View child in _children)
        {
            child.RenderAndDelegateToChildren();
        }
    }

    public void AddChild(View view)
    {
        _children.Add(view);
    }

    public void RemoveChild(View view)
    {
        _children.Remove(view);
    }
}