using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoardObservableView : ObservableView<Board>
{
    public BoardObservableView(Board model) : base(model)
    {
        for (int i = 0; i < model.Area; i++)
        {
            AddChild(new BoxObservableView(model.GetBoxByIndex(i)));
        }
    }

    public override void Render()
    {
        Console.WriteLine("Rendering a board.");
    }
}