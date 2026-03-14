using System;

namespace CorporateInfoPlatformsLab1
{
    public static class ExamArrayTimer
    {
        public static Exam[] CreateOneDimensionalArray(int totalCount)
        {
            Exam[] data = new Exam[totalCount];

            for (int i = 0; i < totalCount; i++)
            {
                data[i] = new Exam(
                    "Algorithms",
                    60 + (i % 41),
                    new DateTime(2025, 2, 1).AddDays(i % 28)
                );
            }

            return data;
        }

        public static Exam[,] CreateRectangularArray(int rows, int columns)
        {
            Exam[,] data = new Exam[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    data[i, j] = new Exam(
                        "Databases",
                        65 + ((i + j) % 31),
                        new DateTime(2025, 3, 1).AddDays((i + j) % 28)
                    );
                }
            }

            return data;
        }

        public static Exam[][] CreateEqualJaggedArray(int rows, int columns)
        {
            Exam[][] data = new Exam[rows][];

            for (int i = 0; i < rows; i++)
            {
                data[i] = new Exam[columns];

                for (int j = 0; j < columns; j++)
                {
                    data[i][j] = new Exam(
                        "Networks",
                        70 + ((i * columns + j) % 21),
                        new DateTime(2025, 4, 1).AddDays((i + j) % 25)
                    );
                }
            }

            return data;
        }

        public static Exam[][] CreateSteppedJaggedArray(int rows, int totalCount)
        {
            Exam[][] data = new Exam[rows][];
            int remaining = totalCount;

            for (int i = 0; i < rows; i++)
            {
                int rowsLeft = rows - i;

                int currentLength;
                if (rowsLeft == 1)
                {
                    currentLength = remaining;
                }
                else
                {
                    int planned = i + 1;
                    int maxAllowed = remaining - (rowsLeft - 1);
                    currentLength = Math.Min(planned, maxAllowed);
                }

                data[i] = new Exam[currentLength];

                for (int j = 0; j < currentLength; j++)
                {
                    data[i][j] = new Exam(
                        "OOP",
                        75 + ((i + j) % 16),
                        new DateTime(2025, 5, 1).AddDays((i + j) % 20)
                    );
                }

                remaining -= currentLength;
            }

            return data;
        }

        public static int MeasureOneDimensional(Exam[] data)
        {
            int start = Environment.TickCount;

            for (int i = 0; i < data.Length; i++)
            {
                data[i].Result += 1;
            }

            return Environment.TickCount - start;
        }

        public static int MeasureRectangular(Exam[,] data)
        {
            int start = Environment.TickCount;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j].Result += 1;
                }
            }

            return Environment.TickCount - start;
        }

        public static int MeasureEqualJagged(Exam[][] data)
        {
            int start = Environment.TickCount;

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    data[i][j].Result += 1;
                }
            }

            return Environment.TickCount - start;
        }

        public static int MeasureSteppedJagged(Exam[][] data)
        {
            int start = Environment.TickCount;

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    data[i][j].Result += 1;
                }
            }

            return Environment.TickCount - start;
        }
    }
}