using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoxView : View<Box>
{
    public BoxView(Box model) : base(model) { }

    public override void Render()
    {
        Console.WriteLine("Rendering a box.");
    }
}