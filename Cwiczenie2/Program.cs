using System;
using System.Collections.Generic;
using System.IO;
using Cwiczenie2.Services;
using Cwiczenie2.Models;

namespace Cwiczenie2
{
    class Program
    {
        static void Main(String[] args)
        {
            String dataPath = "";
            String resultPath = "./result.json";
            String extensionType = "json";
            try {
                if (!String.IsNullOrEmpty(args[0]))
                {
                    dataPath = args[0];
                }
            }
            catch(IndexOutOfRangeException e) {
                dataPath = "D:\\Projekty\\RiderProjects\\Cwiczenie2\\Dane\\dane.csv";
            }

            var isPathValid = dataPath.IndexOfAny(Path.GetInvalidPathChars()) == -1;
            
            if (!isPathValid) {
                throw new ArgumentException("Podana ścieżka jest niepoprawna");
            }

            if (!File.Exists(dataPath)) {
                throw new FileNotFoundException("Plik " + dataPath + " nie istnieje");
            }

            try {
                if (!String.IsNullOrEmpty(args[1])) {
                    resultPath = args[1];
                }
            }
            catch (Exception e) {
                Console.WriteLine("Output path not found, using: " + resultPath);
            }
            
            try {
                if (!String.IsNullOrEmpty(args[2]))
                {
                    extensionType = args[2];
                }
            }
            catch (Exception e) {
                Console.WriteLine("Extension type not found, using: " + extensionType);
            }
            
            Dictionary<string, Student> students = StudentParser.ParseStudentsFromCSV(dataPath);
            University university = new University(students);
            
            if (extensionType.Equals("json")) {
                StudentParser.UniversityToJSON(university, resultPath);
                return;
            }
            throw new ArgumentException("There is no parser for extension");
        }
    }
}