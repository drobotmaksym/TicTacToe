namespace TicTacToe.Model.Board;

public class GameBoard
{
    private readonly Box[] _boxes;

    public GameBoard(int size)
    {
        Size = size;
        _boxes = GenerateBoxes();
    }

    public int Size { get; }

    public int Area => Size * Size;

    public Box this[int column, int row] => _boxes[column + row * Size];

    private Box[] GenerateBoxes()
    {
        var boxes = new Box[Area];
        for (int i = 0; i < Area; i++) boxes[i] = new Box();

        return boxes;
    }

    public Box GetBoxByIndex(int index)
    {
        return _boxes[index];
    }

    public void Clear()
    {
        foreach (Box box in _boxes) box.Piece = Box.Empty;
    }

    public bool IsFilled()
    {
        foreach (Box box in _boxes)
            if (box.Piece == Box.Empty)
                return false;

        return true;
    }
}