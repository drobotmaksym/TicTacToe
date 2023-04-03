namespace TicTacToe.Model.Board;

public class GameBoard
{
    private readonly Box[] _boxes;
    
    public int Size { get; }
    
    public int Area => Size * Size;

    public GameBoard(int size)
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

    public bool IsFilled()
    {
        foreach (Box box in _boxes)
        {
            if (box.Piece == Box.Empty) return false;
        }

        return true;
    }
    
    public Box this[int column, int row] => _boxes[column + row * Size];
}