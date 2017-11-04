using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Configuration;
using ServiceStack.Text;
using System.Data;
using AutoMapper;
using CobbReports.Domain;

namespace CobbReports.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CsvDataSet, Log>().ReverseMap();
            });

            var dataPath = @"C:\Users\jb\Google Drive\CobbData";
            var csvFiles = Directory.GetFileSystemEntries(dataPath, "*.csv");
            var recordsToAdd = new List<LogInfo>();
            foreach (var file in csvFiles)
            {
                LogInfo info = new LogInfo();
                List<string> cleanedFields = new List<string>();
                using (var reader = new StreamReader(file))
                {
                    var firstLine = reader.ReadLine();
                    var fields = CsvReader.ParseFields(firstLine);
                    var lastField = fields.Last();
                    info = new LogInfo(lastField);
                    fields.Remove(lastField);

                    foreach (var field in fields)
                    {
                        var cleanedField = Regex.Replace(field, @"\s\([^)]*\)", string.Empty);
                        cleanedField = Regex.Replace(cleanedField, @"[^a-zA-Z]", string.Empty);
                        if (!cleanedFields.Any(f => f == cleanedField))
                        {
                            cleanedFields.Add(cleanedField);
                        }
                    }
                    cleanedFields.Add("Fake");
                }
                var rows = CsvReader.ParseLines(File.ReadAllText(file));

                var header = rows.First();
                rows.Remove(header);
                var cleanedHeader = string.Join(",", cleanedFields);
                rows.Insert(0, cleanedHeader);

                var data = ServiceStack.Text.CsvReader<CsvDataSet>.Read(rows);
                foreach (var row in data)
                {
                    var stuff = Mapper.Map<CsvDataSet, Log>(row);
                    info.Logs.Add(stuff);
                }
                recordsToAdd.Add(info);
            }
            using (var db = new CobbDbContext())
            {
                db.LogInfos.AddRange(recordsToAdd);
                db.SaveChanges();
            }

            Console.WriteLine("Done");
            Console.Read();

        }
    }
}
