using System;

namespace HomeWork_4._8_2
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            const int PASCAL_TRIANGLE_ROWS = 10;
            int[][] triangleData = GenerateTriangleData(PASCAL_TRIANGLE_ROWS);
            int widthOfMaxNumber = FindWidthOfMaxNumber(triangleData);
            ShowPascalTriangle(triangleData, widthOfMaxNumber);
        }

        /// <summary>
        /// Генерация значений треугольника Паскаля в зависимости от кол-ва строк
        /// </summary>
        /// <param name="rows">Кол-во строк</param>
        /// <returns>Значения треугольника Паскаля в виде массива массивов</returns>
        private static int[][] GenerateTriangleData(int rows)
        {
            int[][] triangleData = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                triangleData[i] = new int[i + 1];
                triangleData[i][0] = 1;
                for (int j = 1; j < i; j++)
                {
                    triangleData[i][j] = triangleData[i - 1][j - 1] + triangleData[i - 1][j];
                }

                triangleData[i][i] = 1;
            }

            return triangleData;
        }

        /// <summary>
        /// Поиск ширины максимального значения треугольника Паскаля
        /// </summary>
        /// <param name="triangleData">Значения треугольника в виде массива массивов</param>
        /// <returns>Ширина</returns>
        private static int FindWidthOfMaxNumber(int[][] triangleData)
        {
            int maxNumber = 0;
            for (int i = 0; i < triangleData.Length; i++)
            {
                for (int j = 0; j < triangleData[i].Length; j++)
                {
                    if (triangleData[i][j] > maxNumber) maxNumber = triangleData[i][j];
                }
            }

            return maxNumber.ToString().Length;
        }


        /// <summary>
        /// Вывод треугольника Паскаля в консоль
        /// </summary>
        /// <param name="triangleData">Значения треугольника в виде массива массивов</param>
        /// <param name="widthOfMaxNumber">Ширина максимального значения в треугольнике</param>
        private static void ShowPascalTriangle(int[][] triangleData, int widthOfMaxNumber)
        {
            int rows = triangleData.Length;
            for (int i = 0; i < rows; i++)
            {
                int leftPaddingRow = (rows - i - 1) * (widthOfMaxNumber + 1) / 2;
                if (leftPaddingRow > 0)
                    WriteSpaces(leftPaddingRow);
                //Console.Write("".PadLeft(leftPaddingRow));

                for (int j = 0; j < triangleData[i].Length; j++)
                {
                    int element = triangleData[i][j];
                    int elementWidth = element.ToString().Length;
                    int elementPadding = widthOfMaxNumber - elementWidth;

                    int padLeft = elementPadding / 2;
                    int padRight = elementPadding - padLeft;

                    WriteSpaces(padLeft);
                    Console.Write(element.ToString());
                    WriteSpaces(padRight);

                    if (j < i) Console.Write(" ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Вывод пробелов в консоль
        /// </summary>
        /// <param name="count">Кол-во пробелов для вывода</param>
        private static void WriteSpaces(int count)
        {
            if (count <= 0) return;

            for (int i = 0; i < count; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
