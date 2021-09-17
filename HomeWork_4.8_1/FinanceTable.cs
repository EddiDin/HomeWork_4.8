using System;
using System.Collections.Generic;

namespace HomeWork_4._8_1
{
    class FinanceTable
    {
        static void Main(string[] args)
        {
            int[,] financeTable = GenerateFinanceTable();
            ShowFinanceTable(financeTable);

            List<Month> Months = GetMonthsListFromTable(financeTable);

            Months.Sort(CompareByProfit);

            Console.WriteLine();
            ShowBadMonths(Months);

            Console.WriteLine();
            Console.WriteLine($"Кол-во месяцев с положительной прибылью: {GetGoodMonthsCount(Months)}");
        }

        /// <summary>
        /// Вывод 3-ех худших месяцев (месяцы с одинаковой прибылью считаются за один)
        /// </summary>
        /// <param name="Months">Список месяцев</param>
        public static void ShowBadMonths(List<Month> Months)
        {
            Console.WriteLine($"Месяцы с худшей прибылью:");

            int badMonthCounter = 0;
            for (int i = 0; i < Months.Count; i++)
            {
                if (badMonthCounter != 3)
                {
                    Console.WriteLine($"Месяц: {Months[i].MonthNumber}   Прибыль: {Months[i].Profit}");
                    if (i + 1 == Months.Count - 1 || Months[i].Profit != Months[i + 1].Profit)
                    {
                        badMonthCounter++;
                    }
                }
            }
        }

        /// <summary>
        /// Получение кол-ва месяцев с положительной прибылью
        /// </summary>
        /// <param name="Months">Список месяцев</param>
        /// <returns>Кол-во месяцев с положительной прибылью</returns>
        public static int GetGoodMonthsCount(List<Month> Months)
        {
            int goodMonthsCounter = 0;
            for (int i = 0; i < Months.Count; i++)
            {
                if (Months[i].Profit > 0) goodMonthsCounter++;
            }

            return goodMonthsCounter;
        }

        /// <summary>
        /// Генерация таблицы финансов
        /// </summary>
        /// <returns>Таблица финансов в виду двумерного массива</returns>
        public static int[,] GenerateFinanceTable()
        {
            Random rand = new Random();
            const int MAX_FINANCE = 500000;
            int[,] financeTable = new int[12, 4];

            for (int i = 0; i < financeTable.GetLength(0); i++)
            {
                for (int j = 0; j < financeTable.GetLength(1); j++)
                {
                    if (j == 0) financeTable[i, j] = i + 1;
                    if (j == 1 || j == 2) financeTable[i, j] = rand.Next(MAX_FINANCE);
                    if (j == 3) financeTable[i, j] = financeTable[i, j - 2] - financeTable[i, j - 1];
                }
            }

            return financeTable;
        }

        /// <summary>
        /// Вывод таблицы финансов в консоль
        /// </summary>
        /// <param name="financeTable">Таблица финансов</param>
        public static void ShowFinanceTable(int[,] financeTable)
        {
            Console.WriteLine($"{"Номер месяца",12} {"Доход",12} {"Расход",12} {"Прибыль",12} ");
            for (int i = 0; i < financeTable.GetLength(0); i++)
            {
                for (int j = 0; j < financeTable.GetLength(1); j++)
                {
                    Console.Write($"{financeTable[i, j],12} ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Функция сравнения элементов списка месяцев из таблицы финансов (List<Month>)
        /// </summary>
        /// <param name="x">Элемент списка</param>
        /// <param name="y">Элемент списка</param>
        /// <returns></returns>
        private static int CompareByProfit(Month x, Month y)
        {
            if (y.Profit < x.Profit) return 1;
            if (y.Profit > x.Profit) return -1;
            return 0;
        }

        /// <summary>
        /// Генерация списка месяцев с прибылью из таблицы финансов
        /// </summary>
        /// <param name="financeTable">Таблица финансов</param>
        /// <returns>Список месяцев с прибылью</returns>
        private static List<Month> GetMonthsListFromTable(int[,] financeTable)
        {
            List<Month> Months = new List<Month>();
            for (int i = 0; i < financeTable.GetLength(0); i++)
            {
                Month month = new Month(financeTable[i, 0], financeTable[i, 3]);
                Months.Add(month);
            }

            return Months;
        }
    }
}
