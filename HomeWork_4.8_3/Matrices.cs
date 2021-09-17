using System;

namespace HomeWork_4._8_3
{
    class Matrices
    {
        static void Main(string[] args)
        {
            ShowHeader("Умножение матрицы на число");

            const int NUMBER_FOR_MULTIPLICATION = 5;
            int[,] matrix = MatrixHelper.Create();
            MatrixHelper.ShowMatrix(matrix, "Матрица до умножения:");
            matrix = MatrixHelper.MatrixMultiplication(matrix, NUMBER_FOR_MULTIPLICATION);
            MatrixHelper.ShowMatrix(matrix, $"Матрица после умножения на {NUMBER_FOR_MULTIPLICATION}:");

            Console.WriteLine();

            ShowHeader("Сложение и вычитание матриц");

            Console.WriteLine("Создание матрицы 1:");
            int[,] matrix1 = MatrixHelper.Create();

            Console.WriteLine();
            Console.WriteLine("Создание матрицы 1:");
            int[,] matrix2 = MatrixHelper.Create();

            Console.WriteLine();
            MatrixHelper.ShowMatrix(matrix1, "Матрица 1:");
            MatrixHelper.ShowMatrix(matrix2, "Матрица 2:");

            Console.WriteLine();
            Console.WriteLine($"Результат сложения матриц:");
            try
            {
                int[,] resultMatrix = MatrixHelper.MatrixAddition(matrix1, matrix2);
                MatrixHelper.ShowMatrix(resultMatrix);
            }
            catch (MatrixException e)
            {
                Console.WriteLine($"Ошибка. {e.Message}");
            }

            Console.WriteLine();
            Console.WriteLine($"Результат вычитания матриц:");
            try
            {
                int[,] resultMatrix = MatrixHelper.MatrixSubtraction(matrix1, matrix2);
                MatrixHelper.ShowMatrix(resultMatrix);
            }
            catch (MatrixException e)
            {
                Console.WriteLine($"Ошибка. {e.Message}");
            }


            Console.WriteLine();

            ShowHeader("Умножение матрицы на матрицу:");
            
            Console.WriteLine("Создание матрицы 1:");
            matrix1 = MatrixHelper.Create();

            Console.WriteLine();
            Console.WriteLine("Создание матрицы 1:");
            matrix2 = MatrixHelper.Create();

            Console.WriteLine();
            MatrixHelper.ShowMatrix(matrix1, "Матрица 1:");
            MatrixHelper.ShowMatrix(matrix2, "Матрица 2:");

            Console.WriteLine();
            Console.WriteLine($"Матрица после умножения матриц 1 и 2:");
            try
            {
                int[,] resultMatrix = MatrixHelper.MatrixMultiplication(matrix1, matrix2);
                MatrixHelper.ShowMatrix(resultMatrix);
            }
            catch (MatrixException e)
            {
                Console.WriteLine($"Ошибка. {e.Message}");
            }

            Console.ReadKey();
        }

        public static void ShowHeader(string message)
        {
            string divider = "----------------------------------------------------";
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
            Console.WriteLine(message);
            Console.SetCursorPosition((Console.WindowWidth - divider.Length) / 2, Console.CursorTop);
            Console.WriteLine(divider);
            Console.WriteLine();
        }
    }
}
