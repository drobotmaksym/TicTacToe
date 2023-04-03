using TicTacToe.Model;
using TicTacToe.Model.Event;

namespace TicTacToe.View;

public abstract class Component : IRenderable
{
    private List<Component> _children = new();
    public readonly static string[] EmptyContainer = new string[] { "" };
    public Position Position { get; set; }
    public Dimension Dimension { get; set; }
    public Rectangle Rectangle => new Rectangle(Position, Dimension);
    public IEnumerable<Component> Children => _children;
    public event Action<KeyPressEvent>? Pressed;

    private Component? GetChildDelegateIfAny(Position position)
    {
        foreach (Component child in _children)
        {
            if (child.Rectangle.Contains(position)) return child;
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
        foreach (string line in representation)
        {
            Console.WriteLine(line);
        }

        foreach (Component child in _children)
        {
            Console.SetCursorPosition(
                Position.X + child.Position.X,
                Position.Y + child.Position.Y
            );
            
            child.Render();
        }
    }
}