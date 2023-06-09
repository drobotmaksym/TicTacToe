﻿using TicTacToe.Controller;
using TicTacToe.Model.Event;
using TicTacToe.Model.Game;
using TicTacToe.View;

namespace TicTacToe;

public class GameLoop
{
    private readonly Game _game;
    private readonly Component _rootComponent;
    private bool _running;

    public GameLoop(Component rootComponent, Game game)
    {
        _rootComponent = rootComponent;
        _game = game;
    }

    internal void Start()
    {
        if (_running) throw new InvalidOperationException("Game loop is alredy running.");

        _running = true;
        _game.Start();
        _rootComponent.OnEnable();
        EnterLoop();
    }

    private void EnterLoop()
    {
        Render(); // Pre-render

        while (_running)
        {
            HandleInput(InputReceiver.ReceiveInput());
            Render();
        }
    }

    private void HandleInput(KeyPressEvent keyPressEvent)
    {
        _rootComponent.Press(keyPressEvent);
    }

    private void Render()
    {
        int cursorX = Console.CursorLeft;
        int cursorY = Console.CursorTop;

        _rootComponent.Render();

        Console.SetCursorPosition(cursorX, cursorY);
    }

    internal void Stop()
    {
        _game.Stop();
        _rootComponent.OnDisable();
        _running = false;
    }
}