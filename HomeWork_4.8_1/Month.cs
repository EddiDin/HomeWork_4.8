using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_4._8_1
{
    class Month
    {
        public int MonthNumber { get; set; }
        public int Profit { get; set; }

        public Month(int monthNumber, int profit) {
            this.MonthNumber = monthNumber;
            this.Profit = profit;
        }
    }
}
