using Microsoft.ML;
using System;
using System.IO;

namespace WineML
{
    class Program
    {
        private static string[] _features = new[] {
            nameof(WineData.FixedAcidity),
            nameof(WineData.VolatileAcidity),
            nameof(WineData.CitricAcid),
            nameof(WineData.ResidualSugar),
            nameof(WineData.Chlorides),
            nameof(WineData.FreeSulfurDioxide),
            nameof(WineData.TotalSulfurDioxide),
            nameof(WineData.Density),
            nameof(WineData.Ph),
            nameof(WineData.Sulphates),
            nameof(WineData.Alcohol)
        };

        static void Main(string[] args)
        {
            PrintHeader("Tasting wine with ML.NET");

            var mlContext = new MLContext();

            Console.Write("Load training data...");
            var trainingData = LoadData(mlContext, "winequality-white-train.csv");
            Console.WriteLine("DONE!");

            Console.Write("Load validation data...");
            var validationData = LoadData(mlContext, "winequality-white-validate.csv");
            Console.WriteLine("DONE!");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static IDataView LoadData(MLContext mlContext, string fileName)
        {
            var dataPath = Path.Combine(Environment.CurrentDirectory, "Data", fileName);
            return mlContext.Data.LoadFromTextFile<WineData>(dataPath, separatorChar: ';', hasHeader: true);
        }

        private static void PrintHeader(string title)
        {
            var originalForegroundColor = Console.ForegroundColor;
            var originalBackgroundColor = Console.BackgroundColor;
            
            var padding = (Console.WindowWidth - title.Length) / 2;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine(".".PadLeft(Console.WindowWidth - 1, ' '));
            Console.WriteLine(".".PadLeft(padding, ' ') + title.ToUpper() + "".PadLeft(padding - 1, ' '));
            Console.WriteLine("".PadLeft(Console.WindowWidth - 1, ' '));

            Console.ForegroundColor = originalForegroundColor;
            Console.BackgroundColor = originalBackgroundColor;
        }
    }
}
