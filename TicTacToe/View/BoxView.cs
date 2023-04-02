using TicTacToe.Model;
using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoxView : ObservableView<Box>
{
    public BoxView(Box box) : base(box)
    {
        Rectangle.Dimension = new Dimension(1, 1);
    }

    public override void Render()
    {
        Console.WriteLine("Rendering a box.");
    }
}