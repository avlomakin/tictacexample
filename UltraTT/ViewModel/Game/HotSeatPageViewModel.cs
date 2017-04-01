using System;
using System.Linq;
using GameLogic;
using UltraTT.Command;
using UltraTT.Model;

namespace UltraTT.ViewModel.Game
{
    public class HotSeatPageViewModel : BaseViewModel
    {
        private const string Cross = "Cross";
        private const string Nought = "Nought";

        private HotSeatModel _model;


        public HotSeatPageViewModel()
        {
            _model = new HotSeatModel();
            _model.NewGame();
            _model.GotWinner += OnGotWinner;
            _model.NeedPickBigCell += OnNeedSelectBigCell;
            _model.SetPlayer += OnSetPlayer;
            _model.ChangeCellPict += OnChangeCellPict;
            _model.ChangeBigCellPict += OnBigCellOwnerChanged;

            PathToCellPict = new string[81];
            PathToBigCellPict = new string[9];
            _currentPlayer = Cross;

            for (int i = 0; i < 9; i++)
            {
                _pathToBigCellPict[i] = null;
                for (int j = 0; j < 9; j++)
                {
                    _pathToCellPict[i * 9 + j] = GetCellPictPath(Cell.Empty);
                }
            }

            _cellClick = new RelayCommand(MakeStep, CheckCell);

        }


        #region Properties

        private string[] _pathToBigCellPict;
        public string[] PathToBigCellPict
        {
            get
            {
                return _pathToBigCellPict;
            }
            set
            {
                _pathToBigCellPict = value;

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

        #endregion

        #region EventHandlers

        public void OnBigCellOwnerChanged(object sender, StringEventArgs args)
        {
            int position = int.Parse(args.Message.Split(',')[0]);
            int owner = int.Parse(args.Message.Split(',')[1]);

            PathToBigCellPict[position] = GetCellPictPath((Cell)owner);
            OnPropertyChanged(nameof(PathToBigCellPict));
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

        #endregion


        public bool CheckCell(object obj)
        {

            var bigCell = CoordChanger(((Tuple<int, int>)obj).Item1, ((Tuple<int, int>)obj).Item2).Item1;
            var position = CoordChanger(((Tuple<int, int>)obj).Item1, ((Tuple<int, int>)obj).Item2).Item2;
            return _model.CheckCell(bigCell, position);
        }

        private void MakeStep(object obj)
        {
            var bigCell = CoordChanger(((Tuple<int, int>)obj).Item1, ((Tuple<int, int>)obj).Item2).Item1;
            var position = CoordChanger(((Tuple<int, int>)obj).Item1, ((Tuple<int, int>)obj).Item2).Item2;

            _model.TryMakeStep(bigCell, position);
        }


       

        private static string GetCellPictPath(Cell cellType)
        {
            switch (cellType)
            {
                case Cell.Empty:
                    return "../../src/game/cells/empty.png";
                case Cell.Cross:
                    return "../../src/game/cells/cross.png";
                case Cell.Nought:
                    return "../../src/game/cells/nought.png";
                default:
                    return null;
            }
        }

       

        private Tuple<int, int> CoordChanger(int x, int y)
        {
            return new Tuple<int, int>((x / 3) * 3 + y / 3, (x % 3) * 3 + y % 3);
        }
    }
}