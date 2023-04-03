using TicTacToe.Model;
using TicTacToe.Model.Event;

namespace TicTacToe.View;

public abstract class Component : IRenderable
{
    private List<Component> _children = new();
    public Rectangle Rectangle;
    public IEnumerable<Component> Children => _children;
    public event Action<KeyPressEvent>? Pressed;
    public ConsoleColor BackgroundColor { get; set; } = RootComponent.DefaultBackgroundColor;
    public ConsoleColor ForegroundColor { get; set; } = RootComponent.DefaultForegroundColor;

    private Component? GetChildDelegateIfAny(Position position)
    {
        foreach (Component child in _children)
        {
            Rectangle absoluteChildRectangle = new Rectangle(
                Rectangle.Position + child.Rectangle.Position,
                child.Rectangle.Dimension
                ); 
            
            if (absoluteChildRectangle.Contains(position)) return child;
        }

        return null;
    }
    
    public void Press(KeyPressEvent keyPressEvent)
    {
        Component? childDelegate = GetChildDelegateIfAny(keyPressEvent.Position);
        if (childDelegate == null)
        {
            Pressed?.Invoke(keyPressEvent);
        }
        else
        {
            childDelegate.Press(keyPressEvent);   
        }
    }
    
    public void AddChild(Component child)
    {
        _children.Add(child);
    }

    public void RemoveChild(Component child)
    {
        _children.Remove(child);
    }

    public abstract IEnumerable<string> Represent();

    public void Render()
    {
        IEnumerable<string> representation = Represent();
        
        Console.BackgroundColor = BackgroundColor;
        Console.ForegroundColor = ForegroundColor;
        
        foreach (string line in representation)
        {
            Console.WriteLine(line);
        }

        foreach (Component child in _children)
        {
            Position absoluteChildPosition = Rectangle.Position + child.Rectangle.Position;
            
            Console.SetCursorPosition(
                absoluteChildPosition.X,
                absoluteChildPosition.Y
            );
            
            child.Render();
        }
    }

    public virtual void OnEnable()
    {
        foreach (Component child in _children) child.OnEnable();
    }

    public virtual void OnDisable()
    {
        foreach (Component child in _children) child.OnDisable();
    }

    public IEnumerable<T> GetChildComponentsOfType<T>() where T : Component
    {
        List<T> components = new();

        foreach (Component child in _children)
        {
            if (child.GetType() == typeof(T)) components.Add((T) child);
            components.AddRange(child.GetChildComponentsOfType<T>());
        }
        
        return components;
    }

    public T? GetDirectChildOfType<T>() where T : Component
    {
        foreach (Component child in _children)
        {
            if (child.GetType() == typeof(T)) return (T) child;
        }

        return null;
    }

    public void Focus()
    {
        Console.SetCursorPosition(
            Rectangle.Position.X,
            Rectangle.Position.Y
            );
    }
}