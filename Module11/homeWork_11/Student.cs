using System;
using System.Collections.Generic;

namespace homeWork_11
{
    public class Student
    {
        public string Name;
        public string Discipline;
        public DateTime? Date;
        public int? Mark;

        public Student(string name, string discipline, DateTime date, int mark)
        {
            Name = name;
            Discipline = discipline;
            Date = date;
            Mark = mark;
        }

        public override string ToString()
        {
            return string.Format($"Name:[{Name}] Discipline:[{Discipline}] Date:[{Date}] Mark:[{Mark}]");
        }
    }
}