using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Cwiczenie2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cwiczenie2.Services
{
    public class StudentParser
    {
        public static Dictionary<string, Student> ParseStudentsFromCSV(string dataPath)
        {
            Logger logger = Logger.GetInstance();
            Dictionary<string, Student> students = new Dictionary<string, Student>();

            var fi = new FileInfo(dataPath);
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');

                    Student student = new Student();

                    try
                    {
                        student.Name = columns[0];
                        student.Surname = columns[1];
                        student.Study = new Study(columns[2], columns[3]);
                        student.StudentId = columns[4];
                        student.Birthdate = DateTime.Parse(columns[5]);
                        student.Email = columns[6];
                        student.MothersName = columns[7];
                        student.FathersName = columns[8];

                        if (students.ContainsKey(student.StudentId))
                        {
                            Exception exception = new DuplicatedStudentDataExceptionException(line);
                            logger.Error(exception);
                        }
                        else
                        {
                            students.Add(student.StudentId, student);
                        }
                    }
                    catch (Exception exception)
                    {
                        Exception richException = new Exception(exception.Message + " -> " + line);
                        logger.Error(richException);
                    }
                }

                stream.Dispose();
            }

            return students;
        }
        
        public static void UniversityToJSON(University university, string outputPath)
        {
            
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };
            
            String json = JsonConvert.SerializeObject(university, jsonSerializerSettings);
            
            File.WriteAllText(outputPath, json);
        }
    }
}