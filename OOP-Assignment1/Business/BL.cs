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
        static DL dl = new DL();
        public bool ValidateMatches(string username)
        {
            Teacher matchesFound = dl.checkUsername(username);

            if (matchesFound != null)
            {
                return true;
            }

            return false;
        }

        public bool login(string username, string password)
        {
            Teacher accountFound = dl.logIn(username,password);

            if (accountFound != null)
            {
                loggedInID = accountFound.TeacherID;
                return true;
            }

            return false;
        }

        public List<string> allGroups()
        {
            List<Group> groups = dl.DisplayGroups();

            List<string> formattedGroups = new List<string>();

            foreach (var group in groups)
            {
                formattedGroups.Add("\n    " + group.GroupID + "                 " + group.Name);
            }

            return formattedGroups;
        }

        public string addLesson(int groupID, DateTime dateTime)
        {
            bool lessonAdded = dl.createLesson(groupID, dateTime, loggedInID);

            if (lessonAdded)
            {
                return "Lesson Created Successfully...";
            }

            return "Error in Lesson Creation...";
        }

        public List<string> allStudentsInGroup(int groupID)
        {
            if (dl.studentsInGroup(groupID).Count > 0)
            {
                return dl.studentsInGroup(groupID);
            }

            return new List<string>();
        }
    }
}
