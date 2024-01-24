using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading.Tasks;

namespace Kviz
{
    public class HistoryElement//jednotka historie, použivá se v History
    {
        public string UserName { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Score { get; set; }

        public HistoryElement() { }

        public HistoryElement(string userName, DateTime dateAndTime, string score)
        {
            UserName = userName;
            DateAndTime = dateAndTime;
            Score = score;
        }

    }
}
