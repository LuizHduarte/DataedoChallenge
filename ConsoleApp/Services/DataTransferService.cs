using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        






        /*
        for (int i = 0; i <= importedLines.Count; i++)
        {
            var importedLine = importedLines[i];
            var values = importedLine.Split(';');
            var importedObject = new ImportedObject();
            //importedObject.Type = values[0];
            importedObject.Name = values[1];
            importedObject.Schema = values[2];
            importedObject.ParentName = values[3];
            importedObject.ParentType = values[4];
            importedObject.DataType = values[5];
            //importedObject.IsNullable = values[6];
            ((List<ImportedObject>)ImportedObjects).Add(importedObject);
        }

        // clear and correct imported data
        foreach (var importedObject in ImportedObjects)
        {
            importedObject.Type = importedObject.Type.Trim().Replace(" ", "").Replace(Environment.NewLine, "").ToUpper();
            importedObject.Name = importedObject.Name.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
            importedObject.Schema = importedObject.Schema.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
            importedObject.ParentName = importedObject.ParentName.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
            importedObject.ParentType = importedObject.ParentType.Trim().Replace(" ", "").Replace(Environment.NewLine, "");

        }
        */
}
