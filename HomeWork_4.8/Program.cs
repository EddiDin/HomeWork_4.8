using System;
using System.Collections.Generic;

namespace HomeWork_4._8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Константа для ограничения генерации рандомного значения для прибыли или расходов в месяц
            const int MAX_FINANCE = 10000000;

            int[,] financeTable = new int[12, 4];
            Random rand = new Random();
            List<Month> Months = new List<Month>();

            // Формирую таблицу с финансовыми показателями.
            // Заодно сразу заношу месяцы в List<Month> для последующей удобной сортировки. Там содержаться объекты с номером месяца и прибылью.
            for (int i = 0; i < financeTable.GetLength(0); i++)
            {
                Month month = new Month();

                for (int j = 0; j < financeTable.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        financeTable[i, j] = i + 1;
                        month.MonthNumber = financeTable[i, j];
                    }
                    if (j == 1 || j == 2)
                    {
                        financeTable[i, j] = rand.Next(MAX_FINANCE);
                    }
                    if (j == 3)
                    {
                        financeTable[i, j] = financeTable[i, j - 2] - financeTable[i, j - 1];
                        month.Profit = financeTable[i, j];
                    }
                }

                Months.Add(month);
            }

            // Вывод таблицы на экран
            Console.WriteLine($"{"Номер месяца",12} {"Доход",12} {"Расход",12} {"Прибыль",12} ");
            for (int i = 0; i < financeTable.GetLength(0); i++)
            {
                for (int j = 0; j < financeTable.GetLength(1); j++)
                {
                    Console.Write($"{financeTable[i, j],12} ");
                }
                Console.WriteLine();
            }

            // Далее сортировка и расчет и вывод худших месяцев (с учетом одинаковых значений) и кол-ва месяцев с положительной прибылью
            Months.Sort(CompareByProfit);

            int badMonthCounter = 0;
            int countGoodMoths = 0;
            Console.WriteLine();
            Console.WriteLine($"Месяцы с худшей прибылью:");
            for (int i = 0; i < Months.Count; i++)
            {
                if (Months[i].Profit > 0) countGoodMoths++;
                if (badMonthCounter != 3)
                {
                    Console.WriteLine($"Месяц: {Months[i].MonthNumber}   Прибыль: {Months[i].Profit}");
                    if (i == 0 || Months[i].Profit != Months[i - 1].Profit)
                    {
                        badMonthCounter++;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Кол-во месяцев с положительной прибылью: {countGoodMoths}");

            // Вывод треугольника Паскаля
            Console.WriteLine();
            Console.WriteLine($"Треугольник Паскаля:");
            int pascalRows = 5;
            int[] prevRow = { };
            for (int i = 0; i < pascalRows; i++)
            {
                int[] row = GeneratePascalRow(prevRow);
                prevRow = row;
                int countSpaces = pascalRows - i;
                for (int j = 0; j < countSpaces; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < row.GetLength(0); j++)
                {
                    Console.Write($"{row[j]} ");
                }

                for (int j = 0; j < countSpaces - 1; j++)
                {
                    Console.Write("");
                }

                Console.WriteLine();
            }


            // Работа с матрицами с учетом исключений
            Console.WriteLine();
            Console.WriteLine("Умножение матрицы на число:");
            const int NUMBER = 5;
            int[,] matrix = MatrixHelper.Generate(6, 6, 1, 9);
            Console.WriteLine("Матрица до умножения:");
            MatrixHelper.ShowMatrix(matrix);
            Console.WriteLine($"Матрица после умножения на {NUMBER}:");
            matrix = MatrixHelper.MatrixMultiplication(matrix, NUMBER);
            MatrixHelper.ShowMatrix(matrix);

            Console.WriteLine();
            Console.WriteLine("Сложение матриц:");
            int[,] matrix1 = MatrixHelper.Generate(2, 2, 1, 9);
            int[,] matrix2 = MatrixHelper.Generate(2, 2, 1, 9);
            Console.WriteLine("Матрица 1:");
            MatrixHelper.ShowMatrix(matrix1);
            Console.WriteLine("Матрица 2:");
            MatrixHelper.ShowMatrix(matrix2);
            Console.WriteLine($"Результат сложения матриц:");
            try
            {
                int[,] resultMatrix = MatrixHelper.MatrixAddition(matrix1, matrix2);
                MatrixHelper.ShowMatrix(resultMatrix);
            }
            catch (MatrixException e)
            {
                Console.WriteLine($"Ошибка! {e.Message}");
            }

            Console.WriteLine($"Результат вычитания матриц:");
            try
            {
                int[,] resultMatrix = MatrixHelper.MatrixSubtraction(matrix1, matrix2);
                MatrixHelper.ShowMatrix(resultMatrix);
            }
            catch (MatrixException e)
            {
                Console.WriteLine($"Ошибка! {e.Message}");
            }


            Console.WriteLine();
            Console.WriteLine("Умножение матрицы на матрицу:");
            matrix1 = MatrixHelper.Generate(2, 2, 1, 9);
            matrix2 = MatrixHelper.Generate(2, 1, 1, 9);
            Console.WriteLine("Матрица 1:");
            MatrixHelper.ShowMatrix(matrix1);
            Console.WriteLine("Матрица 2:");
            MatrixHelper.ShowMatrix(matrix2);
            Console.WriteLine($"Матрица после умножения матриц 1 и 2:");
            try
            {
                int[,] resultMatrix = MatrixHelper.MatrixMultiplication(matrix1, matrix2);
                MatrixHelper.ShowMatrix(resultMatrix);
            }
            catch (MatrixException e)
            {
                Console.WriteLine($"Ошибка! {e.Message}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Генерация следующей строки треугольника Паскаля
        /// </summary>
        /// <param name="prevRow">Предыдущая строка треугольника в ввиде одномерного массива</param>
        /// <returns></returns>
        private static int[] GeneratePascalRow(int[] prevRow)
        {
            int[] row = { 1 };
            if (prevRow.Length == 0) return row;

            int rowLength = prevRow.Length + 1;

            int[] newRow = new int[rowLength];
            for (int i = 0; i < newRow.GetLength(0); i++)
            {
                if (i == 0)
                {
                    newRow[i] = 1;
                    continue;
                }

                if (i < prevRow.Length)
                {
                    newRow[i] = prevRow[i] + prevRow[i - 1];
                    continue;
                }

                newRow[i] = 1;
            }

            return newRow;
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
    }
}
