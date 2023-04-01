namespace TicTacToe;

public class GameRenderer
{
    private readonly View.View _primaryView;

    public GameRenderer(View.View primaryView)
    {
        _primaryView = primaryView;
    }
        
    public void Init()
    {
        throw new NotImplementedException();
    }
    
    public void Render()
    {
        _primaryView.RenderAndDelegateToChildren();
    }
}