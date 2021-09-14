using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_4._8
{
    /// <summary>
    /// Вспомогательный класс, предоставляющий методы работы с матрицами
    /// </summary>
    class MatrixHelper
    {
        /// <summary>
        /// Генерация матрицы
        /// </summary>
        /// <param name="rows">Кол-во строк</param>
        /// <param name="cols">Кол-во столбцов</param>
        /// <param name="minInt">Минимальная граница для заполнения рандомными значениями</param>
        /// <param name="maxInt">Максимальная граница для заполнения рандомными значениями</param>
        /// <returns>Матрица</returns>
        public static int[,] Generate(int rows, int cols, int minInt, int maxInt)
        {
            Random rand = new Random();
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(minInt, maxInt);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Вывод матрицы на экран
        /// </summary>
        /// <param name="matrix">Матрица</param>
        public static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="number">Число</param>
        /// <returns>Матрица</returns>
        public static int[,] MatrixMultiplication(int[,] matrix, int number)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= number;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Умножение матрицы на матрицу
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <returns>Матрица</returns>
        public static int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new MatrixException("При умножении матрицы A на матрицу B число столбцов матрицы A должно быть равно числу строк матрицы B.");
            }

            int[,] resultMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (var i = 0; i < matrix1.GetLength(0); i++)
            {
                for (var j = 0; j < matrix2.GetLength(1); j++)
                {
                    resultMatrix[i, j] = 0;

                    for (var k = 0; k < matrix1.GetLength(1); k++)
                    {
                        resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <returns>Матрица</returns>
        public static int[,] MatrixAddition(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new MatrixException("Складывать можно только одинаковые по размеру матрицы.");
            }

            int[,] resultMatrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Вычитание матриц
        /// </summary>
        /// <param name="matrix1">Первая матрица</param>
        /// <param name="matrix2">Вторая матрица</param>
        /// <returns>Матрица</returns>
        public static int[,] MatrixSubtraction(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new MatrixException("Вычитать можно только одинаковые по размеру матрицы.");
            }

            int[,] resultMatrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return resultMatrix;
        }
    }
}
