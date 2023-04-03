namespace TicTacToe.View;

public class Container : Component
{
    public override IEnumerable<string> Represent()
    {
        return new[] { String.Empty };
    }
}