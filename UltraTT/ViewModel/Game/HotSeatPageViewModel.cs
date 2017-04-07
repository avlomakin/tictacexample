using System;
using System.Collections.Generic;
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
            _cellClick = new RelayCommand(MakeStep, CheckCell);
            _newGameCommand = new SimpleCommand(NewGame);
 
            _smallCells = new List<List<ViewModelCell>>();

            for (int i = 0; i < 9; i++)
            {
                _smallCells.Add(new List<ViewModelCell>());
                for (int j = 0; j < 9; j++)
                {
                    var vmCell = new ViewModelCell();
                    vmCell.Coords = CoordChanger(i, j);
                    _smallCells[i].Add(vmCell);
                }
            }

            _bigCells = new List<List<ViewModelCell>>();

            for (int i = 0; i < 3; i++)
            {
                _bigCells.Add(new List<ViewModelCell>());
                for (int j = 0; j < 3; j++)
                {
                    var vmCell = new ViewModelCell();
                    vmCell.Coords = null;
                    _bigCells[i].Add(vmCell);
                }
            }
            
            NewGame();
        }


        #region Properties

        public double CellSize => 30;

        private List<List<ViewModelCell>> _smallCells;
        public List<List<ViewModelCell>> SmallCells
        {
            get
            {
                return _smallCells;
            }
            set
            {
                _smallCells = value;

                OnPropertyChanged();
            }
        }

        /// <summary></summary>
        private List<List<ViewModelCell>> _bigCells;
        public List<List<ViewModelCell>> BigCells
        {
            get
            {
                return _bigCells;
            }
            set
            {
                _bigCells = value;

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


        private SimpleCommand  _newGameCommand;
        public SimpleCommand  NewGameCommand
        {
            get
            {
                return _newGameCommand;
            }
            set
            {
                _newGameCommand = value;

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


        #endregion

        #region EventHandlers

        public void OnBigCellOwnerChanged(object sender, StringEventArgs args)
        {
            int position = int.Parse(args.Message.Split(',')[0]);
            int owner = int.Parse(args.Message.Split(',')[1]);

            BigCells[position / 3][position % 3].PictSource = GetBigCellPictPath((Cell)owner);
        }


        public void OnGotWinner(object sender, StringEventArgs args)
        {
            CurrentPlayer = $"Got winner: {_currentPlayer}";
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

            SmallCells[i][j].PictSource = GetCellPictPath(CurrentPlayer == Cross ? Cell.Cross : Cell.Nought);
        }

        public void OnSetPlayer(object sender, StringEventArgs args)
        {
            CurrentPlayer = args.Message;
        }

        #endregion


        public void NewGame()
        {
            _model = new HotSeatModel();
            _model.NewGame();
            _model.GotWinner += OnGotWinner;
            _model.SetPlayer += OnSetPlayer;
            _model.ChangeCellPict += OnChangeCellPict;
            _model.ChangeBigCellPict += OnBigCellOwnerChanged;

            _currentPlayer = Cross;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _smallCells[i][j].PictSource = GetCellPictPath(Cell.Empty);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _bigCells[i][j].PictSource = GetBigCellPictPath(Cell.Empty);
                }
            }


        }

        public bool CheckCell(object obj)
        {
            if (obj == null) return true;
            var bigCell = ((Tuple<int, int>)obj).Item1;
            var position =((Tuple<int, int>)obj).Item2;
            return _model.CheckCell(bigCell, position);
        }

        private void MakeStep(object obj)
        {
            var bigCell = ((Tuple<int, int>)obj).Item1;
            var position = ((Tuple<int, int>)obj).Item2;

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

        private static string GetBigCellPictPath(Cell cellType)
        {
            switch (cellType)
            {
                case Cell.Empty:
                    return "../../src/game/cells/empty.png";
                case Cell.Cross:
                    return "../../src/game/cells/big_cross.png";
                case Cell.Nought:
                    return "../../src/game/cells/big_nought.png";
                default:
                    return null;
            }
        }

        private static Tuple<int, int> CoordChanger(int x, int y)
        {
            return new Tuple<int, int>((x / 3) * 3 + y / 3, (x % 3) * 3 + y % 3);
        }
    }
}