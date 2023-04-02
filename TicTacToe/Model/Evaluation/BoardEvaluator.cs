using System.Net;
using System.Runtime.CompilerServices;
using TicTacToe.Model.Board;
using TicTacToe.Model.Dash;
using TicTacToe.Model.Game;

namespace TicTacToe.Model.Evaluation;

// Violates SRP, but I could not find a better solution.
public class BoardEvaluator
{
    public static Evaluation EvaluateAndGenerateDash(Board.Board board)
    {
        Dash.Dash? rowEvaluation = EvaluateRows(board);
        Dash.Dash? columnEvaluation = EvaluateColumns(board);
        Dash.Dash? primaryDiagonalEvaluation = EvaluatePrimaryDiagonal(board);
        Dash.Dash? secondaryDiagonalEvaluation = EvaluateSecondaryDiagonal(board);
        
        if (rowEvaluation != null) 
            return new Evaluation(GameState.Win, rowEvaluation);
        
        if (columnEvaluation != null) 
            return new Evaluation(GameState.Win, columnEvaluation);
        
        if (primaryDiagonalEvaluation != null) 
            return new Evaluation(GameState.Win, primaryDiagonalEvaluation);
        
        if (secondaryDiagonalEvaluation != null) 
            return new Evaluation(GameState.Win, secondaryDiagonalEvaluation);
        
        return new Evaluation(GameState.Intermediate);
    }

    private static Dash.Dash? EvaluateRows(Board.Board board)
    {
        for (int j = 0; j < board.Size; j++)
        {
            var positions = new Position[board.Size];
            char lastPiece = board[0, j].Piece;
            int matches = 0;

            for (int i = 0; i < board.Size; i++)
            {
                char currentPiece = board[i, j].Piece;
                if (currentPiece != lastPiece || currentPiece == Box.Empty) break;
                positions[matches] = new Position(i, j);
                lastPiece = currentPiece;
                matches++;
            }

            if (matches == board.Size) return new Dash.Dash(Orientation.Horizontal, positions);
        }
        
        return null;
    }
    
    private static Dash.Dash? EvaluateColumns(Board.Board board)
    {
        for (int i = 0; i < board.Size; i++)
        {
            var positions = new Position[board.Size];
            char lastPiece = board[i, 0].Piece;
            int matches = 0;

            for (int j = 0; j < board.Size; j++)
            {
                char currentPiece = board[i, j].Piece;
                if (currentPiece != lastPiece || currentPiece == Box.Empty) break;
                positions[matches] = new Position(i, j);
                lastPiece = currentPiece;
                matches++;
            }

            if (matches == board.Size) return new Dash.Dash(Orientation.Vertical, positions);
        }
        
        return null;
    }
    
    private static Dash.Dash? EvaluatePrimaryDiagonal(Board.Board board)
    {
        var positions = new Position[board.Size];
        char lastPiece = board[0, 0].Piece;
        int matches = 0;
        
        for (int i = 0; i < board.Size; i++)
        {
            char currentPiece = board[i, i].Piece;
            if (currentPiece != lastPiece || currentPiece == Box.Empty) break;
            
            positions[matches] = new Position(i, i);
            lastPiece = currentPiece;
            matches++;
        }

        return matches == board.Size ? new Dash.Dash(Orientation.PrimaryDiagonal, positions) : null;
    }

    private static Dash.Dash? EvaluateSecondaryDiagonal(Board.Board board)
    {
        var positions = new Position[board.Size];
        char lastPiece = board[board.Size - 1, 0].Piece;
        int matches = 0;
        
        for (int i = 0; i < board.Size; i++)
        {
            char currentPiece = board[board.Size - i - 1, i].Piece;
            if (currentPiece != lastPiece || currentPiece == Box.Empty) break;
            
            positions[matches] = new Position(board.Size - i - 1, i);
            lastPiece = currentPiece;
            matches++;
        }

        return matches == board.Size ? new Dash.Dash(Orientation.SecondaryDiagonal, positions) : null;
    }
}