using ConsoleApp.Services;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = @"data.csv";
            OrquestrationService.StartOrquestration(csvFilePath);
        }
    }
}
