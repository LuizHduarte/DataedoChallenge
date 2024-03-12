using ConsoleApp.Models;
using System.Collections.Generic;

namespace ConsoleApp.Services
{
    public class OrquestrationService
    {
        public static void StartOrquestration(string csvPath)
        {
            List<string> list = ReaderService.ImportData(csvPath);
            List<Database> CorrectedDatabase = DataTransferService.SetAndCorrectData(list);
            List<Database> AssignedChildrens = DataTransferService.AssingNumberOfChildrens(CorrectedDatabase);
            PrintService.Print(AssignedChildrens);

        }
    }
}
