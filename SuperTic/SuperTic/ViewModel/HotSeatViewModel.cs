using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using GameLib;
using SuperTic.Command;
using SuperTic.Model;

namespace SuperTic.ViewModel
{
    public class HotSeatViewModel : BaseViewModel
    {
        private const string Cross = "Cross";
        private const string Nought = "Nought";

        private HotSeatModel _model;


        public HotSeatViewModel()
        {
            _model = new HotSeatModel();
            _model.NewGame();
            _model.GotWinner += OnGotWinner;
            _model.NeedPickBigCell += OnNeedSelectBigCell;
            _model.SetPlayer += OnSetPlayer;
            _model.ChangeCellPict += OnChangeCellPict;

            PathToCellPict = new string[81];
            _currentPlayer = Cross;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _pathToCellPict[i*9 + j] = GetCellPictPath(Cell.Empty);
                }
            }

            _cellClick = new RelayCommand(MakeStep, CheckCell);

        }


        private string _s = "../src/cells/empty.png";
        public string S
        {
            get
            {
                return _s;
            }
            set
            {
                _s = value;

                OnPropertyChanged();
            }
        }


        private RelayCommand _cellClick;
        public RelayCommand CellClick
        {
            get
            {
                return _cellClick;
            }
            set
            {
                _cellClick = value;
                OnPropertyChanged();
            }
        }


        private string _currentPlayer;//Cross or Nought
        public string CurrentPlayer
        {
            get
            {
                return _currentPlayer;
            }
            set
            {
                _currentPlayer = value;

                OnPropertyChanged();
            }
        }


        private bool _isBigCellSelected;
        public bool IsBigCellSelected
        {
            get
            {
                return _isBigCellSelected;
            }
            set
            {
                _isBigCellSelected = value;

                OnPropertyChanged();
            }
        }


        private string[] _pathToCellPict;
        public string[] PathToCellPict
        {
            get
            {
                return _pathToCellPict;
            }
            set
            {
                _pathToCellPict = value;

                OnPropertyChanged();
            }
        }



        public bool CheckCell(object obj)
        {

            var bigCell = CoordChanger(((Tuple<int, int>) obj).Item1, ((Tuple<int, int>) obj).Item2).Item1;
            var position = CoordChanger(((Tuple<int, int>) obj).Item1, ((Tuple<int, int>) obj).Item2).Item2;
            return _model.CheckCell(bigCell, position);
        }

        private void MakeStep(object obj)
        {
            var bigCell = CoordChanger(((Tuple<int, int>) obj).Item1, ((Tuple<int, int>) obj).Item2).Item1;
            var position = CoordChanger(((Tuple<int, int>) obj).Item1, ((Tuple<int, int>) obj).Item2).Item2;

            _model.TryMakeStep(bigCell, position);
        }


        public void OnGotWinner(object sender, StringEventArgs args)
        {
            CurrentPlayer = $"Got winner: {_currentPlayer}";
        }

        public void OnNeedSelectBigCell(object sender, EventArgs args)
        {
            _isBigCellSelected = false;
        }

        public void OnBigCellSelected(object sender, EventArgs args)
        {
            _isBigCellSelected = true;
        }

        public void OnChangePlayer(object sender, EventArgs args)
        {
            CurrentPlayer = CurrentPlayer == Cross ? Cross : Nought;
        }

        public void OnChangeCellPict(object sender, StringEventArgs args)
        {
            var bigCell = args.Message.Split(',').Select(Int32.Parse).ToArray()[0];
            var position = args.Message.Split(',').Select(Int32.Parse).ToArray()[1];

            var i = CoordChanger(bigCell, position).Item1;
            var j = CoordChanger(bigCell, position).Item2;

            PathToCellPict[i * 9 + j] = GetCellPictPath(CurrentPlayer == Cross ? Cell.Cross : Cell.Nought);
            OnPropertyChanged(nameof(PathToCellPict));
        }

        public void OnSetPlayer(object sender, StringEventArgs args)
        {
            CurrentPlayer = args.Message;
        }

        private static string GetCellPictPath(Cell cellType)
        {
            switch (cellType)
            {
                case Cell.Empty:
                    return "../src/cells/empty.png";
                case Cell.Cross:
                    return "../src/cells/cross.png";
                case Cell.Nought:
                    return "../src/cells/nought.png";
                default:
                    return null;
            }
        }


        private Tuple<int, int> CoordChanger(int x, int y)
        {
            return new Tuple<int, int>((x/3)*3 + y/3, (x%3)*3 + y%3);
        }
    }
}