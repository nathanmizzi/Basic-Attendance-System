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
        public int loggedInID;
        public int lastLessonID;
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

        public void AddGroup(string groupName,string courseName)
        {
            dl.NewGroup(groupName,courseName);
        }

        public bool AddStudent(int groupID,string name,string surname, string email)
        {
            bool groupFound = dl.NewStudent(groupID,name,surname,email);

            return groupFound;
        }

        public bool AddTeacher(string username,string password,string name,string surname,string email)
        {
            if (!String.IsNullOrEmpty(username) || !String.IsNullOrEmpty(password) || !String.IsNullOrEmpty(name) ||
                !String.IsNullOrEmpty(surname) || !String.IsNullOrEmpty(email))
            {
                dl.NewTeacher(username,password,name,surname,email);
            }

            return false;
        }

        public bool VerifyStudentID(int proposedID)
        {
            if (proposedID != null)
            {
                if (dl.VerifyStudent(proposedID) != null)
                {
                    return true;
                }
            }

            return false;
        }

        public List<string> ReturnAttendencePercentage(int studentID)
        {
            List<StudentAttendance> matchingAttendences = dl.GetAttendances(studentID);

            List<string> matches = new List<string>();

            foreach (var matchingAttendence in matchingAttendences)
            {
                matches.Add(matchingAttendence.Student.Name + " " + matchingAttendence.Student.Surname + " " 
                            + matchingAttendence.Lesson.DateTime + " " + matchingAttendence.Presence);
                
            }

            //To add attendance percentage formula
            //matches.Add("\n" + );

            return;
        }
    }
}
