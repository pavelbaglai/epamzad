using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;

namespace homeWork_11
{
    public class Filter
    {
        public string StudentName { get; }
        public string Discipline { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public int? MinMark { get;  }
        public int? MaxMark { get; }
        public int Number { get; }
        public Filter(string inputStr)
        {
            if(string.IsNullOrEmpty(inputStr)) throw new ArgumentNullException();
            inputStr = inputStr.TrimStart('-');
            List<string> parameters = inputStr.Split('-').Select(p => p.Trim()).ToList(); // 0- name, 1- lesson, 2- start date, 3- end date, 4- min mark, 5- max mark, 6- quanity
            if (parameters.Count<6) throw new ArgumentException();

            StudentName = parameters[0];
            Discipline = parameters[1];
            DateTime startdate;
            if (DateTime.TryParseExact(parameters[2], "yyyyMMdd",CultureInfo.InvariantCulture, DateTimeStyles.None, out startdate))
            { StartDate = startdate;}
            else
            {
                throw new FormatException();
            }
            DateTime enddate;
            if (DateTime.TryParseExact(parameters[3], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out enddate))
            { EndDate= enddate;}
            else
            {
                throw new FormatException();
            }
            int minmark;
            if(int.TryParse(parameters[4],out minmark))
            { MinMark = minmark;}
            else
            {
                throw new FormatException();
            }
            int maxmark;
            if (int.TryParse(parameters[5], out maxmark))
            { MaxMark = maxmark;}
            else
            {
                throw new FormatException();
            }
            int number;
            if (int.TryParse(parameters[6], out number)) { Number = number;}
            else
            {
                throw new FormatException();
            }
        }
    }
}