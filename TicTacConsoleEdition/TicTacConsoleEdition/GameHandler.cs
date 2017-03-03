using System;
using GameLib;

namespace TicTacConsoleEdition
{
    public class GameHandler
    {
        private bool _isCurrentCross;
        private int _currentCell;
        public Field GameField { get; private set; }
        public bool NeedChangeCell { get; private set; }
        public Cell Winner { get; private set; }

        public GameHandler()
        {
            _isCurrentCross = true;
        }

        public void StartGame()
        {

            Console.ForegroundColor = ConsoleColor.White;
            _isCurrentCross = true;
            NeedChangeCell = true;
            GameField = new Field();
            Step();
        }

        public void ShowField()
        {
            Console.WriteLine(" -----------------");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("| ");
                    for (int k = 0; k < 3; k++)
                    {
                        string curString = null;
                        if ((i*3 + k) == _currentCell && !NeedChangeCell)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        for (int h = j * 3; h < (j + 1) * 3; h++)
                        {
                            var cell = GameField.FineField[i*3 + k].Cells[h];
                            switch (cell)
                            {

                                case Cell.Empty:
                                    curString += ".";
                                    break;
                                case Cell.Cross:
                                    curString += "x";
                                    break;
                                case Cell.Nought:
                                    curString += "o";
                                    break;
                            }
                        }
                        Console.Write(curString);
                        if ((i * 3 + k) == _currentCell && !NeedChangeCell)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.Write(" | ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(" -----------------");
            }
        }

        public void Step()
        {
            ShowField();

            string curPlayer = _isCurrentCross ? Cell.Cross.ToString() : Cell.Nought.ToString();
            Console.WriteLine("Current player: " + curPlayer);

            if (NeedChangeCell || IsCurrentCellFull())
            {
                ChangeCell();
            }

            bool ok = false;
            int position = 0;

            while (!ok)
            {
                Console.WriteLine("Choose small cell(0..8)");
                try
                {
                    position = int.Parse(Console.ReadLine());
                    ok = GameField.TrySet(_currentCell, position, _isCurrentCross ? Cell.Cross : Cell.Nought);
                    if(!ok)
                        Console.WriteLine("Ups, try again");
                }
                catch (Exception)
                {
                    Console.WriteLine("Ups, try again");
                }
            }

            Winner = GameField.Check();

            if (Winner != Cell.Empty)
            {
                Console.WriteLine("We have a winner: " + Winner + ". Congratulations!");
                return;
            }
            _isCurrentCross = !_isCurrentCross;
            _currentCell = position;

            if (GameField.CoarseField.Cells[position] != Cell.Empty)
            {
                NeedChangeCell = true;
            }

            Step();
        }

        private bool IsCurrentCellFull()
        {
            var result = true;
            foreach (var cell in GameField.FineField[_currentCell].Cells)
            {
                if (cell == Cell.Empty)
                {
                    result = false;
                }
            }
            return result;
        }

        private void ChangeCell()
        {
            bool ok = false;
            while (!ok)
            {
                ok = true;
                try
                {

                    Console.WriteLine("Choose big cell(0..8)");
                    _currentCell = int.Parse(Console.ReadLine());
                    if(GameField.CoarseField.Cells[_currentCell] != Cell.Empty || IsCurrentCellFull())
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Something is bad, try again");
                    ok = false;
                }
            }
            NeedChangeCell = false;
        }
    }
}