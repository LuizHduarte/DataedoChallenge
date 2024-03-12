using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
