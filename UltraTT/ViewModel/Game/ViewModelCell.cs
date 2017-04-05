using System;

namespace UltraTT.ViewModel.Game
{
    public class ViewModelCell : BaseViewModel
    {


        private string _pictSource;
        public string PictSource
        {
            get
            {
                return _pictSource;
            }
            set
            {
                _pictSource = value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Big cell id, position
        /// </summary>
        public Tuple<int, int> Coords { get; set; }
    }
}