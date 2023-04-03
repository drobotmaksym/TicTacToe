using TicTacToe.Model;
using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoxComponent : Component
{
    public Box Box { get; }

    public BoxComponent(Box box)
    {
        Rectangle.Dimension = new Dimension(1, 1);
        Box = box;
    }

    public override IEnumerable<string> Represent()
    {
        return new[] { Box.Piece.ToString() };
    }
}