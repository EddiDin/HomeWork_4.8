using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_4._8_1
{
    class Month
    {
        /// <summary>
        /// Номер месяца
        /// </summary>
        public int MonthNumber { get; set; }
        
        /// <summary>
        /// Прибыль 
        /// </summary>
        public int Profit { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="monthNumber">Номер масяца</param>
        /// <param name="profit">Прибыль</param>
        public Month(int monthNumber, int profit) {
            this.MonthNumber = monthNumber;
            this.Profit = profit;
        }
    }
}
