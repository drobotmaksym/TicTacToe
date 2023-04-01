﻿using TicTacToe.Model.Dash;
using TicTacToe.Model.Evaluation;
using TicTacToe.Model.Event;
using TicTacToe.Model.Game;
using TicTacToe.View;

namespace TicTacToe.Controller;

public class GameController : IInputObserver<BoardObservableView>
{
    private Game _game;
    private BoardEvaluator _boardEvaluator;
    private Dash _dash;
    
    public void HandleKeyPress(BoardObservableView boardObservableView, KeyPressEvent keyPressEvent)
    {
        Evaluation evaluation = _boardEvaluator.EvaluateAndGenerateDashInfo(boardObservableView.Model);
        HandleGameState(evaluation.GameState, evaluation.DashInfo); // Smells bad.
    }

    private void HandleGameState(GameState gameState, DashInfo? dashInfo)
    {
        switch (gameState)
        {
            case GameState.Win:
                if (dashInfo == null) throw new ArgumentException("");
                _game.Statistics.IncreaseWinsFor(_game.CurrentPlayer);
                _game.Stop();
                _dash.DashInfo = dashInfo;
                break;
            case GameState.Tie:
                _game.Statistics.IncreaseTies();
                _game.Stop();
                break;
            case GameState.Intermediate:
                _game.SwitchPlayer();
                break;
            default:
                throw new ArgumentException("");
        }
    }
}