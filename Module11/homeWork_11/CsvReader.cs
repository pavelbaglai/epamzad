using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace homeWork_11
{
    public class CsvReader
    {
        public static List<Student> Exec(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException();
            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"source\" + fileName);
            if (!File.Exists(filePath))
                if(Path.GetExtension(fileName) == "csv")
                throw new FileNotFoundException();

            var StudentList = new List<Student>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] strSplitted = line.Split(';');
                    if (strSplitted.Length<4) throw new ArgumentException();
                    DateTime datetime;
                    if (!DateTime.TryParseExact(strSplitted[2], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime)) 
                        throw new FormatException();
                    Student p = new Student(strSplitted[0], strSplitted[1], datetime, Convert.ToInt32(strSplitted[3]));
                    StudentList.Add(p);
                }
            }
            return StudentList;
        }
    }
}