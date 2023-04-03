using TicTacToe.Model.Board;
using TicTacToe.Model.Dash;
using TicTacToe.Model.Game;

namespace TicTacToe.Model;

public static class BoardEvaluator
{
    public static event Action<BoardDash>? DashGenerated;

    private static void NotifyDashGenerationListeners(BoardDash dash)
    {
        DashGenerated?.Invoke(dash);
    }
    
    public static GameState EvaluateAndGenerateDash(GameBoard board)
    {
        if (IsRowMatch(board) ||
            IsColumnMatch(board) ||
            IsPrimaryDiagonalMatch(board) ||
            IsSecondaryDiagonalMatch(board)) return GameState.Win;

        return board.IsFilled() ? GameState.Tie : GameState.Intermediate;
    }

    private static bool IsRowMatch(GameBoard board)
    {
        for (int i = 0; i < board.Size; i++)
        {
            char firstPiece = board[0, i].Piece;  
            int matches = 0; 
 
            for (int j = 0; j < board.Size; j++)
            {
                char currentPiece = board[j, i].Piece;
                if (currentPiece != firstPiece || currentPiece == Box.Empty) break;
                matches++;
            }

            if (matches == board.Size)
            {
                NotifyDashGenerationListeners(new BoardDash(DashOrientation.Horizontal, i));
                return true;
            }
        }

        return false;
    }
    
    private static bool IsColumnMatch(GameBoard board)
    {
        for (int i = 0; i < board.Size; i++)
        {
            char firstPiece = board[i, 0].Piece;  
            int matches = 0; 
 
            for (int j = 0; j < board.Size; j++)
            {
                char currentPiece = board[i, j].Piece;
                if (currentPiece != firstPiece || currentPiece == Box.Empty) break;
                matches++;
                
                if (matches == board.Size)
                {
                    NotifyDashGenerationListeners(new BoardDash(DashOrientation.Vertical, i));
                    return true;
                }
            }
        }

        return false;
    }

    private static bool IsPrimaryDiagonalMatch(GameBoard board)
    {
        char firstPiece = board[0, 0].Piece;
        int matches = 0;
        
        for (int i = 0; i < board.Size; i++)
        {
            char currentPiece = board[i, i].Piece;
            if (currentPiece != firstPiece || currentPiece == Box.Empty) break;
            matches++;
        }

        bool match = matches == board.Size;
        if (match)
        {
            NotifyDashGenerationListeners(
                new BoardDash(DashOrientation.PrimaryDiagonal)
            );
        }
        
        return match;
    }

    private static bool IsSecondaryDiagonalMatch(GameBoard board)
    {
        char firstPiece = board[board.Size - 1, 0].Piece;
        int matches = 0;
        
        for (int i = 0; i < board.Size; i++)
        {
            char currentPiece = board[board.Size - i - 1, i].Piece;
            if (currentPiece != firstPiece || currentPiece == Box.Empty) break;
            matches++;
        }

        bool match = matches == board.Size;
        if (match)
        {
            NotifyDashGenerationListeners(
                new BoardDash(DashOrientation.SecondaryDiagonal)
            );
        }
        
        return match;
    }
}