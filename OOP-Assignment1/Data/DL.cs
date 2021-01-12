using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Data
{
    public class DL
    {
        MasterEntities db = new MasterEntities();

        public Teacher CheckUsername(string username)
        {
            var records = db.Teacher;

            var recordsQuery =
                from record in records
                where record.Username == username
                select record;

            return recordsQuery.SingleOrDefault();
        }

        public Teacher LogIn(string username, string password)
        {
            var records = db.Teacher;

            var recordsQuery =
                from record in records
                where record.Username == username && record.Password == password
                select record;

            return recordsQuery.SingleOrDefault();
        }

        public List<Group> DisplayGroups()
        {
            var records = db.Group;

            var recordsQuery =
                from record in records
                select record;

            List<Group> groups = new List<Group>();

            foreach (var record in recordsQuery)
            {
                groups.Add(record);
            }

            return groups;
        }

        public int CreateLesson(int groupID, DateTime dateTime, int teacherID)
        {
            try
            {
                Lesson L = new Lesson
                {
                    GroupID = groupID,
                    DateTime = dateTime,
                    TeacherID = teacherID
                };

                db.Lesson.Add(L);
                db.SaveChanges();

                return L.LessonID;
            }
            catch
            {
                return -1;
            }
        }

        public List<string> StudentsInGroup(int groupID)
        {
            List<string> studentsInGroup = new List<string>();

            var records = db.Student;

            var recordsQuery =
                from record in records
                where record.GroupID == groupID
                select record;

            foreach (var record in recordsQuery)
            {
                studentsInGroup.Add( record.StudentID + "\t\t\t" + record.Name + "\t\t\t" + record.Surname + "\t\t\t");
            }

            return studentsInGroup;
        }

        public void SubmitAttendance(List<string> students, int currentLessonID)
        {
            foreach (var student in students)
            {
                int studentIDEnd = student.IndexOf("\t");
                bool prescence = false;

                try
                {
                    int studentID = Convert.ToInt32(student.Substring(0, studentIDEnd));
                    char prescenceChar = student.Last();

                    if (prescenceChar == 'p')
                    {
                        prescence = true;
                    }

                    StudentAttendance SA = new StudentAttendance
                    {
                        LessonID = currentLessonID,
                        Presence = prescence,
                        StudentID = studentID
                    };

                    db.StudentAttendance.Add(SA);
                    db.SaveChanges();
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Fatal Error");
                    Console.ReadKey();
                }
            }
        }

        public bool NewGroup(string groupName, string courseName)
        {
            try
            {

                Group g = new Group
                {
                    Name = groupName,
                    Course = courseName
                };

                db.Group.Add(g);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool NewStudent(int groupID, string name, string surname, string email)
        {
            var records = db.Group;

            var recordsQuery =
                from record in records
                where record.GroupID == groupID
                select record;

            if (recordsQuery.Count() > 0)
            {
                Student s = new Student
                {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    GroupID = groupID
                };

                db.Student.Add(s);
                db.SaveChanges();

                return true;
            }

            return false;
        }

        public bool NewTeacher(string username, string password, string name, string surname, string email)
        {
            try
            {
                Teacher t = new Teacher
                {
                    Username = username,
                    Password = password,
                    Name = name,
                    Surname = surname,
                    Email = email
                };

                db.Teacher.Add(t);
                db.SaveChanges();

                return false;
            }
            catch
            {
                return false;
            }
        }

        public Student VerifyStudent(int proposedID)
        {
            var records = db.Student;

            var recordsQuery =
                from record in records
                where record.StudentID == proposedID
                select record;

            return recordsQuery.SingleOrDefault();
        }

        public double GetAttendances(int groupID, int studentID)
        {
            var records = db.StudentAttendance;

            var recordsQuery =
                from record in records
                where record.Lesson.GroupID == groupID && record.StudentID == studentID
                select record;

            List<StudentAttendance> allAttendences = new List<StudentAttendance>();

            foreach (var studentAttendance in recordsQuery)
            {
                allAttendences.Add(studentAttendance);
            }

            return allAttendences.Count;
        }

        public double GetSpecificAttendances(int studentID)
        {
            var records = db.StudentAttendance;

            var recordsQuery =
                from record in records
                where record.StudentID == studentID && record.Presence == true
                select record;

            List<StudentAttendance> specificAttendances = new List<StudentAttendance>();

            foreach (var studentAttendance in recordsQuery)
            {
                specificAttendances.Add(studentAttendance);
            }

            return specificAttendances.Count;
        }

        public int GetAttendancesOnDay(int teacherID,int day,int month,int year)
        {
            DateTime dateTime = new DateTime(year, month, day);

            var records = db.Lesson;

            var recordsQuery =
                from record in records
                where DbFunctions.TruncateTime(record.DateTime) == DbFunctions.TruncateTime(dateTime) && record.Teacher.TeacherID == teacherID
                select record;

            List<Lesson> lessonsOnDay = new List<Lesson>();

            foreach (var lesson in recordsQuery)
            {
                lessonsOnDay.Add(lesson);
            }

            return lessonsOnDay.Count;
        }

        public bool EditStudent(int studentID,string name,string surname,string email)
        {
            try
            {
                var records = db.Student;

                var student =
                    from record in records
                    where record.StudentID == studentID
                    select record;

                Student studentToEdit = student.SingleOrDefault();

                studentToEdit.Name = name;
                studentToEdit.Surname = surname;
                studentToEdit.Email = email;

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }

 }

