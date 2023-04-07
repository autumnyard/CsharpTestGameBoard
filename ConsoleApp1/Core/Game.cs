﻿using ConsoleApp1.Display;
using ConsoleApp1.Gameplay;
using ConsoleApp1.Gameplay.Game;
using ConsoleApp1.Input;

namespace ConsoleApp1.Core
{
    internal class Game : IPersistable<GamePersistence>
    {
        private Displayer _displayer;
        private IInputProvider _inputProvider;
        private MainGameLogic _mainGame;

        public bool IsRunning => _mainGame.IsRunning;

        public void Initialize()
        {

            _displayer = new Displayer();

            _inputProvider = new InputProvider();
            _displayer.AddDisplayable((IDisplayable)_inputProvider);

            _mainGame = new MainGameLogic();
            _displayer.AddDisplayable((IDisplayable)_mainGame);
        }

        public void NewGame(int level)
        {
            _mainGame.NewGame(level);
        }

        public void Load(GamePersistence persistence)
        {
            _mainGame.Load(persistence);
        }

        public GamePersistence Save()
        {
            return _mainGame.Save();
        }

        public void Tick()
        {
            Console.Clear();
            _displayer.Display();
            _inputProvider.GetInput(out var newInput);
            _mainGame.ApplyInput(newInput);
        }

        public void Finish()
        {
            _displayer.RemoveDisplayable((IDisplayable)_mainGame);
            _displayer.RemoveDisplayable((IDisplayable)_inputProvider);
        }

    }
}