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

    public void AddChild<TChild>(ObservableView<TChild> child)
    {
        Children.Add(child);
    }

    public void RemoveChild<TChild>(ObservableView<TChild> child)
    {
        Children.Remove(child);
    }

    public void Subscribe(IInputObserver<T> inputObserver)
    {
        _observers.Add(inputObserver);
    }

    public void Unsubscribe(IInputObserver<T> inputObserver)
    {
        _observers.Remove(inputObserver);
    }

    private void DelegateKeyPressHandleToObservers(KeyPressEvent keyPressEvent)
    {
        foreach (var observer in _observers)
        {
            observer.OnKeyPress(Model, keyPressEvent);
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

    public override void PressKey(KeyPressEvent keyPressEvent)
    {
        View? childDelegate = GetChildDelegateIfAny(keyPressEvent.Position);
        if (childDelegate == null)
        {
            DelegateKeyPressHandleToObservers(keyPressEvent);
        }
        else
        {
            childDelegate.PressKey(keyPressEvent);
        }
    }

    public List<ObservableView<TChild>> GetChildrenOfType<TChild>()
    {
        List<ObservableView<TChild>> children = new();
        foreach (View child in Children)
        {
            if (IsViewOfType<TChild>(child) == false) continue;
            children.Add((ObservableView<TChild>) child);
        }
        return children;
    }

    private static bool IsViewOfType<TChild>(View view)
    {
        Type? baseType = view.GetType().BaseType;
        Type? argument = baseType?.GetGenericArguments().FirstOrDefault();
        return argument == typeof(TChild);
    }

    public abstract override void Render();
}