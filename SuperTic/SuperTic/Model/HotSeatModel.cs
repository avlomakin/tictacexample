﻿
using System;
using System.Windows;
using GameLib;

namespace SuperTic.Model
{
    public class HotSeatModel
    {
        private bool _isCross;
        private int _currentCell; //0..9, -1 means free
        public Field GameField { get; private set; }
        public Cell Winner { get; private set; }

        public event StringEventHandler GotWinner;
        public event EventHandler NeedPickBigCell;
        public event StringEventHandler ChangeCellPict;
        public event StringEventHandler SetPlayer;

        public void NewGame()
        {
            _currentCell = -1;
            _isCross = true;
            GameField = new Field();
            Winner = Cell.Empty;
        }

        public void TryMakeStep(int bigCell, int position)
        {
            if (_currentCell != -1 && _currentCell != bigCell)
            {
                return;
            }

            _currentCell = bigCell;

            GameField.TrySet(_currentCell, position, _isCross ? Cell.Cross : Cell.Nought);

            ChangeCellPict?.Invoke(this, new StringEventArgs($"{bigCell},{position}"));

            Winner = GameField.Check();

            if (Winner != Cell.Empty)
            {
                NotifyAboutWinner();
                return;
            }

            _isCross = !_isCross;
            SetPlayer?.Invoke(this, new StringEventArgs(_isCross ? "Cross" : "Nought"));
            _currentCell = position;

            if (GameField.CoarseField.Cells[position] != Cell.Empty)
            {
                _currentCell = -1;
                NeedPickBigCell?.Invoke(this, new EventArgs());
            }

        }

        public bool CheckCell(int bigCell, int smallCell)
        {

            if ((bigCell == _currentCell || _currentCell == -1)
                && GameField.FineField[bigCell].Cells[smallCell] == Cell.Empty
                && GameField.CoarseField.Cells[bigCell] == Cell.Empty)
            {
                return true;
            }
            return false;
        }

        private void NotifyAboutWinner()
        {
            GotWinner?.Invoke(this, new StringEventArgs(_isCross ? "Cross" : "Nought"));
        }
    }
}
