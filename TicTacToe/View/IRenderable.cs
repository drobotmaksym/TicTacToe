namespace TicTacToe.View;

public interface IRenderable
{
    public IEnumerable<string> Represent();

    public void Render();
}