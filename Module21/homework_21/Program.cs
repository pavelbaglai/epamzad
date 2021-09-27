using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_21
{
    class Program
    {
        static void Main(string[] args)
        {
            var university = new University();
            university.InitDatabase();
            university.AddStudent("Andrey");
            university.AddLecture(new DateTime(2017, 01, 01),"ADONET");
            university.AddAttend(new DateTime(2017,01,01), "Andrey",3);
            university.MarkAttendance(new DateTime(2017, 02, 01), "Andrey2", 3);
            university.ShowReport();
            Console.ReadKey();
        }
    }
}
