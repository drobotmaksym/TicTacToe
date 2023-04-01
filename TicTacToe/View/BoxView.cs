using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoxObservableView : ObservableView<Box>
{
    public BoxObservableView(Box model) : base(model) { }

    public override void Render()
    {
        Console.WriteLine("Rendering a box.");
    }
}