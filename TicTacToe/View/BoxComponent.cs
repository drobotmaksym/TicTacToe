using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoxComponent : Component
{
    private Box _box;

    public BoxComponent(Box box)
    {
        _box = box;
        Dimension.Width = 1;
        Dimension.Height = 1;
    }

    public override IEnumerable<string> Represent()
    {
        return new[] { _box.Piece.ToString() };
    }
}