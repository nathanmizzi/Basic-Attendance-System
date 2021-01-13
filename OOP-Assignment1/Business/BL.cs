using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;

namespace Business
{
    public class BL
    {
        private int loggedInID;
        private int lastLessonID;
        private int studentGroup;
        static DL dl = new DL();
        public bool ValidateMatches(string username)
        {
            Teacher matchesFound = dl.CheckUsername(username);

            if (matchesFound != null)
            {
                return true;
            }

            return false;
        }

        public bool Login(string username, string password)
        {
            Teacher accountFound = dl.LogIn(username,password);

            if (accountFound != null)
            {
                loggedInID = accountFound.TeacherID;
                return true;
            }

            return false;
        }

        public List<string> AllGroups()
        {
            List<Group> groups = dl.DisplayGroups();

            List<string> formattedGroups = new List<string>();

            foreach (var group in groups)
            {
                formattedGroups.Add("\n    " + group.GroupID + "                 " + group.Name);
            }

            return formattedGroups;
        }

        public string AddLesson(int groupID, DateTime dateTime)
        {
            int lessonAdded = dl.CreateLesson(groupID, dateTime, loggedInID);

            if (lessonAdded != -1)
            {
                lastLessonID = lessonAdded;
                return "Lesson Created Successfully...";
            }

            return "Error in Lesson Creation...";
        }

        public List<string> AllStudentsInGroup(int groupID)
        {
            if (dl.StudentsInGroup(groupID).Count > 0)
            {
                return dl.StudentsInGroup(groupID);
            }

            return new List<string>();
        }

        public void AddAttendance(List<string> attendanceInfo)
        {
            dl.SubmitAttendance(attendanceInfo,lastLessonID);
        }

        public bool AddGroup(string groupName,string courseName)
        {
            if (!string.IsNullOrEmpty(groupName) && !string.IsNullOrEmpty(courseName))
            {
                return dl.NewGroup(groupName, courseName);
            }

            return false;
        }

        public bool AddStudent(int groupID,string name,string surname, string email)
        {
            if (dl.VerifyGroup(groupID) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(email))
            {
                bool groupFound = dl.NewStudent(groupID, name, surname, email);

                return groupFound;
            }

            return false;
        }

        public bool AddTeacher(string username,string password,string name,string surname,string email)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(email))
            {
                if (dl.CheckUsername(username) == null)
                {
                    if (dl.NewTeacher(username, password, name, surname, email))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool VerifyStudentID(int proposedID)
        {
            Student s = dl.VerifyStudent(proposedID);

            if (s != null)
            {
                studentGroup = s.GroupID;
                return true;
            }

            return false;
        }

        public double ReturnAttendancePercentage(int studentID)
        {
            double allAttendances = dl.GetAttendances(studentGroup,studentID);

            double matchingAttendances = dl.GetSpecificAttendances(studentID);

            double attendancePercentage = (matchingAttendances / allAttendances) * 100;
            
            return attendancePercentage;
        }

        public string ReturnAttendancesOnDay(int day, int month, int year)
        {
            if (day >= 1 && day <= 31 && month >= 1 && month <= 12)
            {
                int attendanceCount = dl.GetAttendancesOnDay(loggedInID,day, month, year);

                return "\nNumber of attendances submitted on given day: " +
                       attendanceCount;
            }

            return "\nInvalid Date";
        }

        public bool AttemptEditStudent(int studentID, string name, string surname, string email)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(email))
            {
                return dl.EditStudent(studentID, name, surname, email);
            }

            return false;
        }

    }
}
