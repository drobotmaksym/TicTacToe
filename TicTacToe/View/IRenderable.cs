namespace TicTacToe.View;

public interface IRenderable
{
    void Render();

    void RenderAndDelegateToChildren();
}