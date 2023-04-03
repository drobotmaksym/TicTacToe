using TicTacToe.Model;
using TicTacToe.Model.Board;
using TicTacToe.Model.Dash;
using TicTacToe.Model.Game;

namespace TicTacToe.View;

public class DashComponent : Container
{
    private GameBoard _gameBoard;
    private BoardDash? _boardDash;
    
    public DashComponent(GameBoard gameBoard)
    {
        _gameBoard = gameBoard;
        
        BoardEvaluator.DashGenerated += (boardDash) =>
        {
            _boardDash = boardDash;
            Display();
        };

        Game.GameRestarted += () => _boardDash = null;
    }

    public void Display()
    {
        if (_boardDash == null) return;
        
        switch (_boardDash.Orientation)
        {
            case DashOrientation.Horizontal:
                for (int i = 0; i < _gameBoard.Size; i++)
                {
                    _gameBoard[i, _boardDash.Position].Piece = '-';
                }
                break;
            case DashOrientation.Vertical:
                for (int i = 0; i < _gameBoard.Size; i++)
                {
                    _gameBoard[_boardDash.Position, i].Piece = '|';
                }
                break;
            case DashOrientation.PrimaryDiagonal:
                for (int i = 0; i < _gameBoard.Size; i++)
                {
                    _gameBoard[i, i].Piece = '\\';
                }
                break;
            case DashOrientation.SecondaryDiagonal:
                for (int i = 0; i < _gameBoard.Size; i++)
                {
                    _gameBoard[_gameBoard.Size - 1 - i, i].Piece = '/';
                }
                break;
        }
    }
}