using TicTacToe.Model.Board;
using TicTacToe.Model.Dash;
using TicTacToe.Model.Game;

namespace TicTacToe.Model.Evaluation;

public class BoardEvaluator
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
        return IsStraightLineMatch(
            board,
            getFirstPiece: index => board[0, index].Piece,
            forRows: true
        );
    }
    
    private static bool IsColumnMatch(GameBoard board)
    {
        return IsStraightLineMatch(
            board,
            getFirstPiece: index => board[index, 0].Piece,
            forRows: false
            );
    }

    private static bool IsStraightLineMatch(
        GameBoard board,
        GetFirstPiece getFirstPiece,
        bool forRows
        )
    {
        for (int i = 0; i < board.Size; i++)
        {
            char firstPiece = getFirstPiece(i);  
            int matches = 0; 
 
            for (int j = 0; j < board.Size; j++)
            {
                char currentPiece = board[
                    forRows ? j : i,
                    forRows ? i : j
                ].Piece;
                
                if (currentPiece != firstPiece || currentPiece == Box.Empty) break;
                matches++;
            }

            if (matches == board.Size)
            {
                var orientation = forRows ? DashOrientation.Horizontal : DashOrientation.Vertical;
                NotifyDashGenerationListeners(new BoardDash(orientation, i));
                return true;
            }
        }

        return false;
    }

    private static bool IsPrimaryDiagonalMatch(GameBoard board)
    {
        bool match = IsDiagonalMatch(
            board,
            firstPiece: board[0, 0].Piece,
            getCurrentPiece: (index) => board[index, index].Piece
        );

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
        bool match = IsDiagonalMatch(
            board,
            firstPiece: board[board.Size - 1, 0].Piece,
            getCurrentPiece: (index) => board[board.Size - index - 1, index].Piece
        );
        
        if (match)
        {
            NotifyDashGenerationListeners(
                new BoardDash(DashOrientation.SecondaryDiagonal)
            );
        }
        
        return match;
    }

    private static bool IsDiagonalMatch(
        GameBoard board,
        char firstPiece,
        GetCurrentPiece getCurrentPiece
        )
    {
        int matches = 0;
        
        for (int i = 0; i < board.Size; i++)
        {
            char currentPiece = getCurrentPiece(i);
            if (currentPiece != firstPiece || currentPiece == Box.Empty) break;
            matches++;
        }
        
        return matches == board.Size;
    }

    private delegate char GetFirstPiece(int index);
    
    private delegate char GetCurrentPiece(int index);
}