using System;

namespace UltraTT.Model
{
    public delegate void StringEventHandler(object sender, StringEventArgs args);

    public class StringEventArgs : EventArgs
    {
        public string Message { get; set; }

        public StringEventArgs(string s)
        {
            Message = s;
        }

    }
}