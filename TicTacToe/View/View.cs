using TicTacToe.Model;
using TicTacToe.Model.Event;

namespace TicTacToe.View;

public abstract class View : IRenderable, IKeyListener
{
    // Potentially unsafe
    protected List<View> Children = new();

    public Rectangle Rectangle;
    
    public abstract void Render();
    
    public abstract void PressKey(KeyPressEvent keyPressEvent);
    
    public void RenderAndDelegateToChildren()
    {
        Render();
        Children.ForEach(childView => childView.RenderAndDelegateToChildren());
    }
}