namespace TicTacToe.Model.Board;

public class Board
{
    private readonly Box[] _boxes;
    
    public int Size { get; }
    
    public int Area => Size * Size;

    public Board(int size)
    {
        Size = size;
        _boxes = GenerateBoxes();
    }

    private Box[] GenerateBoxes()
    {
        var boxes = new Box[Area];
        for (int i = 0; i < Area; i++)
        {
            boxes[i] = new Box();
        }

        return boxes;
    }

    public Box GetBoxByIndex(int index)
    {
        return _boxes[index];
    }
}