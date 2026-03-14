using System;

namespace CorporateInfoPlatformsLab1
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Student student = new Student();

            Console.WriteLine("1. Student in short form:");
            Console.WriteLine(student.ToShortString());
            Console.WriteLine();

            Console.WriteLine("2. Indexer check:");
            Console.WriteLine($"Education.Master -> {student[Education.Master]}");
            Console.WriteLine($"Education.Bachelor -> {student[Education.Bachelor]}");
            Console.WriteLine($"Education.SecondEducation -> {student[Education.SecondEducation]}");
            Console.WriteLine();

            student = new Student
            {
                PersonInfo = new Person("Andrii", "Marchuk", new DateTime(2005, 11, 25)),
                EducationForm = Education.Master,
                GroupNumber = 312,
                Exams = new Exam[]
                {
                    new Exam("Discrete Mathematics", 95, new DateTime(2025, 6, 20)),
                    new Exam("Programming", 98, new DateTime(2025, 6, 24))
                }
            };

            Console.WriteLine("3. Full information after assigning values:");
            Console.WriteLine(student.ToString());
            Console.WriteLine();

            student.AddExams(
                new Exam("Operating Systems", 91, new DateTime(2025, 6, 26)),
                new Exam("English", 88, new DateTime(2025, 6, 27))
            );

            Console.WriteLine("4. Information after AddExams():");
            Console.WriteLine(student.ToString());
            Console.WriteLine();

            ReadArraySizes(out int nRows, out int nColumns);

            int totalElements = checked(nRows * nColumns);

            Exam[] oneDimensional = ExamArrayTimer.CreateOneDimensionalArray(totalElements);
            Exam[,] rectangular = ExamArrayTimer.CreateRectangularArray(nRows, nColumns);
            Exam[][] jaggedEqual = ExamArrayTimer.CreateEqualJaggedArray(nRows, nColumns);
            Exam[][] jaggedStepped = ExamArrayTimer.CreateSteppedJaggedArray(nRows, totalElements);

            int oneDimensionalTime = ExamArrayTimer.MeasureOneDimensional(oneDimensional);
            int rectangularTime = ExamArrayTimer.MeasureRectangular(rectangular);
            int jaggedEqualTime = ExamArrayTimer.MeasureEqualJagged(jaggedEqual);
            int jaggedSteppedTime = ExamArrayTimer.MeasureSteppedJagged(jaggedStepped);

            Console.WriteLine("5. Timing comparison:");
            Console.WriteLine($"nRows = {nRows}, nColumns = {nColumns}, total = {totalElements}");
            Console.WriteLine($"Exam[]                  -> {oneDimensionalTime} ms");
            Console.WriteLine($"Exam[,]                 -> {rectangularTime} ms");
            Console.WriteLine($"Exam[][] (equal rows)   -> {jaggedEqualTime} ms");
            Console.WriteLine($"Exam[][] (stepped rows) -> {jaggedSteppedTime} ms");
            Console.WriteLine();
            Console.WriteLine("Note: if arrays are too small, some values may be 0 ms.");
        }

        private static void ReadArraySizes(out int nRows, out int nColumns)
        {
            char[] separators = { ' ', ',', ';', ':', '\t' };

            while (true)
            {
                Console.Write("Enter nRows and nColumns: ");
                string input = Console.ReadLine() ?? string.Empty;

                string[] parts = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                {
                    Console.WriteLine("You must enter exactly two numbers.");
                    continue;
                }

                bool rowsOk = int.TryParse(parts[0], out nRows);
                bool columnsOk = int.TryParse(parts[1], out nColumns);

                if (!rowsOk || !columnsOk)
                {
                    Console.WriteLine("Input must contain only integers.");
                    continue;
                }

                if (nRows <= 0 || nColumns <= 0)
                {
                    Console.WriteLine("Both numbers must be greater than zero.");
                    continue;
                }

                long total = (long)nRows * nColumns;
                if (total > int.MaxValue)
                {
                    Console.WriteLine("The numbers are too large. Enter smaller values.");
                    continue;
                }

                break;
            }
        }
    }
}