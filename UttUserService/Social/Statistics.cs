using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UttUserService.Social
{
    public class Statistics
    {
        public double TotalWinrate { get; }

        public double CrossWinrate { get; }

        public double NoughtWinrate { get; }

        public int MatchPlayed { get; }

        public Statistics(double totalWinrate, double crossWinrate,
            double noughtWinrate, int matchPlayed)
        {
            TotalWinrate = totalWinrate;
            CrossWinrate = crossWinrate;
            NoughtWinrate = noughtWinrate;
            MatchPlayed = matchPlayed;
        }
    }
}
