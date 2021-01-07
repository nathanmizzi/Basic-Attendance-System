using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace OOP_Assignment1_Presentation
{
    class PL
    {
        static BL bl = new BL();
        static void Main(string[] args)
        {
            int userchoice = 0;
            string username = string.Empty;
            List<string> menuOptions = new List<string>();
            menuOptions.AddRange(new List<string> { "Login", "Exit" });

            while (userchoice != 2)
            {
                menuMaker("Main Menu", menuOptions);
                try
                {
                    Console.Write("Enter Choice: ");
                    userchoice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    displayError();
                }

                if (userchoice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Login\n=====\n");
                    Console.Write("Username: ");
                    username = Console.ReadLine();

                    //Check if username already exists in the system
                    if (bl.ValidateMatches(username))
                    {
                        Console.Write("Password: ");
                        string password = Console.ReadLine();
                        if (bl.Login(username, password))
                        {
                            //Show teachers Menu
                            while (true)
                            {
                                menuMaker("Teachers Menu", new List<string>
                                {"Add Attendance","Add a New Group"
                                ,"Add a New Student","Add a New Teacher"
                                ,"Check a student's attendance percentage"
                                ,"Get all attendances submitted on a particular day"
                                ,"Edit Student"});

                                int optionChosen = 0;

                                try
                                {
                                    Console.Write("\nEnter Choice: ");
                                    optionChosen = Convert.ToInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    displayError();
                                }

                                switch (optionChosen)
                                {
                                    case 1:

                                    Console.Clear();

                                    int selectedGroupID = 0;

                                    while (selectedGroupID == 0)
                                    {

                                        menuMaker("Groups", new List<string> { });

                                        Console.WriteLine("Group ID         Group Name");

                                        List<string> groups = bl.AllGroups();

                                        foreach (var group in groups)
                                        {
                                            Console.WriteLine(group);
                                        }

                                        Console.Write("\nPlease input your selected Group ID: ");
                                        try
                                        {
                                            selectedGroupID = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch
                                        {
                                            displayError();
                                        }

                                        Console.WriteLine(bl.AddLesson(selectedGroupID, DateTime.Now));

                                        Console.WriteLine("\nPress Any Key To Continue");
                                        Console.ReadKey();

                                        Console.Clear();

                                        List<string> studentsInClass = bl.AllStudentsInGroup(selectedGroupID);

                                        menuMaker("New Attendance",new List<string>());
                                        Console.WriteLine("\nGroup ID: " + selectedGroupID);
                                        Console.WriteLine("Student ID\t\tStudent Name\t\tStudent Surname\t\tPresence(P/A)");
                                        Console.WriteLine("==========\t\t============\t\t===============\t\t=============");
                                        foreach (var student in studentsInClass)
                                        {
                                            Console.WriteLine(student);
                                        }

                                        int startingCursorPosition = 6;

                                        for (int i = 0; i < studentsInClass.Count; i++)
                                        {
                                            Console.SetCursorPosition(72, startingCursorPosition);
                                            char status = Console.ReadKey().KeyChar;

                                            switch (status)
                                            {
                                                    case 'p':
                                                        startingCursorPosition++;
                                                        studentsInClass[i] = studentsInClass[i] + "p";
                                                        break;
                                                    case 'a':
                                                        startingCursorPosition++;
                                                        studentsInClass[i] = studentsInClass[i] + "a";
                                                        break;
                                                    default:
                                                        Console.Write("\b \b");
                                                        i--;
                                                        break;
                                            }
                                        }

                                        bl.AddAttendance(studentsInClass);
                                    }

                                    break;

                                    case 2:
                                        //To be tested
                                        Console.Clear();

                                        Console.Write("Please input group name: ");
                                        string chosenGroupName = Console.ReadLine();

                                        Console.Write("Please input course name: ");
                                        string chosenCourseName = Console.ReadLine();

                                        bl.AddGroup(chosenGroupName,chosenCourseName);

                                        break;
                                    case 3:
                                        //To be tested
                                        Console.Clear();

                                        Console.Write("Please input group ID: ");
                                        int chosenGroupID = Convert.ToInt32(Console.ReadLine());

                                        Console.Write("Please input student name: ");
                                        string studentName = Console.ReadLine();

                                        Console.Write("Please input student surname: ");
                                        string studentSurname = Console.ReadLine();

                                        Console.Write("Please input student email: ");
                                        string studentEmail = Console.ReadLine();

                                        if (bl.AddStudent(chosenGroupID,studentName,studentSurname,studentEmail))
                                        { 
                                            Console.WriteLine("Successfully added student");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Failed to add student");
                                        }

                                        break;
                                    case 4:
                                        //To be tested
                                        Console.Clear();
                                        
                                        Console.Write("\n Please input new teacher username: ");
                                        string teacherUsername = Console.ReadLine();

                                        Console.Write("\nPlease input new teacher password: ");
                                        string teacherPassword = Console.ReadLine();

                                        Console.Write("\nPlease input new teacher Name: ");
                                        string teacherName = Console.ReadLine();

                                        Console.Write("\nPlease input new teacher Surname: ");
                                        string teacherSurname = Console.ReadLine();

                                        Console.Write("\nPlease input new teacher Email: ");
                                        string teacherEmail = Console.ReadLine();

                                        if (bl.AddTeacher(teacherUsername, teacherPassword, teacherName, teacherSurname,
                                            teacherEmail))
                                        {
                                            Console.WriteLine("\nTask Performed Successfully");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            displayError();
                                        }

                                        break;
                                    case 5:
                                        //To be Tested
                                        Console.Clear();

                                        Console.Write("Please input student ID: ");

                                        try
                                        {
                                            int proposedStudentID = Convert.ToInt32(Console.ReadLine());
                                            if (bl.VerifyStudentID(proposedStudentID))
                                            {
                                                
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nNo Student with that ID found.");
                                            }
                                        }
                                        catch
                                        {
                                            displayError();
                                        }

                                        break;
                                    case 6:
                                        break;
                                    case 7:
                                        break;
                                }

                            }

                        }

                        Console.WriteLine("Password Incorrect.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("The entered ID does not exist in our system.");
                        Console.ReadKey();
                    }

                }
            }
        }

        public static void menuMaker(string menuName, List<string> menuOptions)
        {
            int cnt = 0;
            Console.Clear();
            Console.WriteLine(menuName);

            for (int i = 0; i < menuName.Length; i++)
            {
                Console.Write("=");

                if (i == menuName.Length - 1)
                {
                    Console.Write("\n");
                }
            }

            foreach (string menuOption in menuOptions)
            {
                cnt++;
                Console.WriteLine(cnt + ". " + menuOption);
            }
        }

        public static void displayError()
        {
            Console.Clear();
            Console.WriteLine("Please Input a number, not a letter or special character and make sure all requested inputs are filled.");
            Console.WriteLine("\nPress any key to continue..");
            Console.ReadKey();
        }
    }
}
