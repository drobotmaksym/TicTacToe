using TicTacToe.Controller;
using TicTacToe.Model;
using TicTacToe.Model.Board;

namespace TicTacToe.View;

public class BoardComponent : Component
{
    public GameBoard Board { get; }

    public BoardComponent(GameBoard board)
    {
        Board = board;
        AddBoxes();
    }

    private void AddBoxes()
    {
        for (int i = 0; i < Board.Size; i++)
        {
            for (int j = 0; j < Board.Size; j++)
            {
                BoxComponent boxComponent = new BoxComponent(Board[j, i]);
                boxComponent.Position = new Position(j, i);
                boxComponent.Pressed += (pressEvent) => KeyNavigator.Navigate(pressEvent, this);
                AddChild(boxComponent);
            }
        }
    }

    public override IEnumerable<string> Represent()
    {
        return EmptyContainer;
    }
}