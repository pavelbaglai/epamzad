using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using homework_21.DBContext;

namespace homework_21
{
    public class University
    {
        DatabaseContext db = new DatabaseContext();
        private string queryStr;
        public void InitDatabase()
        {
            queryStr = @" IF OBJECT_ID ('dbo.Student') IS NULL
                          CREATE TABLE Student (Name nvarchar(255))";
            db.QueryBuilder(queryStr);
            var k = db.ExecNonQuery(null);
            queryStr = @"CREATE TABLE Lecture (Date datetime, Topic nvarchar(255))";
            db.QueryBuilder(queryStr);
            k = db.ExecNonQuery(null);
            queryStr = @"CREATE TABLE Attendance (LectureDate datetime, StudentName nvarchar(255), Mark int)";
            db.QueryBuilder(queryStr);
            k = db.ExecNonQuery(null);
            queryStr =
                @"
                CREATE PROCEDURE MarkAttendance 
                @LectureDate datetime,
                @StudentName nvarchar(255), 
                @Mark int

                AS
                SET NOCOUNT ON;
                Insert into Attendance values (@LectureDate,@StudentName, @Mark)
                ";
            db.QueryBuilder(queryStr);
            k=db.ExecNonQuery(null);
        }
        public void AddLecture(DateTime dateLecture,string topicName)
        {
            SqlParameter parameterDateLecture = new SqlParameter("@DateLecture", SqlDbType.DateTime);
            parameterDateLecture.Value = dateLecture;
            SqlParameter parameterTopicName = new SqlParameter("@TopicName", SqlDbType.NVarChar);
            parameterTopicName.Value = topicName;
            queryStr = "Insert into Lecture values(@DateLecture,@TopicName)";
            db.QueryBuilder(queryStr);
            var k = db.ExecNonQuery(parameterDateLecture, parameterTopicName);
        }
        public void AddStudent(string studentName)
        {
            SqlParameter parameterStudentName = new SqlParameter("@StudentName", SqlDbType.NVarChar);
            parameterStudentName.Value = studentName;
            queryStr = "Insert into Student values(@StudentName)";
            db.QueryBuilder(queryStr);
            var k = db.ExecNonQuery(parameterStudentName);
        }
        public void AddAttend(DateTime dateLecture, string studentName, int mark)
        {
            SqlParameter parameterDateLecture = new SqlParameter("@DateLecture", SqlDbType.DateTime);
            parameterDateLecture.Value = dateLecture;
            SqlParameter parameterStudentName = new SqlParameter("@StudentName", SqlDbType.NVarChar);
            parameterStudentName.Value = studentName;
            SqlParameter parameterMark = new SqlParameter("@Mark", SqlDbType.Int);
            parameterMark.Value = mark;
            queryStr = "Insert into Attendance values(@DateLecture,@StudentName, @Mark)";
            db.QueryBuilder(queryStr);
            var k = db.ExecNonQuery(parameterDateLecture, parameterStudentName, parameterMark);
        }
        public void MarkAttendance(DateTime dateLecture, string studentName, int mark)
        {
            SqlParameter parameterDateLecture = new SqlParameter("@LectureDate", SqlDbType.DateTime);
            parameterDateLecture.Value = dateLecture;
            SqlParameter parameterStudentName = new SqlParameter("@StudentName", SqlDbType.NVarChar);
            parameterStudentName.Value = studentName;
            SqlParameter parameterMark = new SqlParameter("@Mark", SqlDbType.Int);
            parameterMark.Value = mark;
            queryStr = "EXEC MarkAttendance @LectureDate,@StudentName,@Mark;";
            db.QueryBuilder(queryStr);
            var k = db.ExecNonQuery(parameterDateLecture, parameterStudentName, parameterMark);
        }
        public void ShowReport()
        {
            queryStr = @"Select st.Name, LectureDate, lec.Topic as TopicName
                         from Student st
                         left join Attendance at on st.Name = at.StudentName
                         left join Lecture lec on lec.Date = at.LectureDate";
            db.QueryBuilder(queryStr);
            using (SqlDataReader reader = db.ExecReader())
            {
                Console.WriteLine("{0,-20}{1,-20}{2,-20}", "StudentName", "LectureDate", "TopicName");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,-20}{1,-20:D}{2,-20}", reader["Name"],
                            reader["LectureDate"], reader["TopicName"]);
                    }
                }
            }
        }

    }
}