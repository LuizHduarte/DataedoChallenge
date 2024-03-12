using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Services
{
    public class DataTransferService
    {

        public static List<Database> SetAndCorrectData(List<string> ImportedData)
        {
            List<Database> databases = new List<Database>();

            foreach (string line in ImportedData)
            {

                var splitedObject = line.Split(';');


                databases.Add(new Database()
                {
                    Type = splitedObject[0].Trim().Replace(" ", "").Replace(Environment.NewLine, "").ToUpper(),
                    Name = splitedObject[1].Trim().Replace(" ", "").Replace(Environment.NewLine, ""),
                    Schema = splitedObject[2].Trim().Replace(" ", "").Replace(Environment.NewLine, ""),
                    ParentName = splitedObject[3].Trim().Replace(" ", "").Replace(Environment.NewLine, ""),
                    ParentType = splitedObject[4].Trim().Replace(" ", "").Replace(Environment.NewLine, "").ToUpper(),
                    DataType = splitedObject[5].Trim().Replace(" ", "").Replace(Environment.NewLine, ""),
                    IsNullable = splitedObject[6].Trim().Replace(" ", "").Replace(Environment.NewLine, ""),
                    NumberOfChildren = 0
                });
            }

            return databases;
        }

        public static List<Database> AssingNumberOfChildrens(List<Database> ImportedData)
        {
            for (int i = 0; i < ImportedData.Count(); i++)
            {
                var iterableObject = ImportedData.ToArray()[i];
                foreach (var subObject in ImportedData)
                {
                    if (subObject.ParentType == iterableObject.Type)
                    {
                        if (subObject.ParentName == iterableObject.Name)
                        {
                            iterableObject.NumberOfChildren++;
                        }
                    }
                }
            }

            return ImportedData;
        }

    }
}
