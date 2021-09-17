using System;

namespace HomeWork_4._8
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}
