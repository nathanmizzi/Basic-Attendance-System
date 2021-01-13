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
            int userChoice = 0;
            string username = string.Empty;
            List<string> menuOptions = new List<string>();
            menuOptions.AddRange(new List<string> { "Login", "Exit" });

            while (userChoice != 2)
            {
                do
                {
                    MenuMaker("Main Menu", menuOptions);

                    Console.Write("Enter Choice: ");
                    int.TryParse(Console.ReadLine(), out userChoice);

                    if (userChoice == 0)
                    {
                        DisplayError();
                    }

                } while (userChoice == 0);

                if (userChoice == 1)
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
                            int optionChosen = 0;

                            //Show teachers Menu
                            while (optionChosen != 8)
                            {
                                do
                                {
                                    MenuMaker("Teachers Menu", new List<string>
                                    {"Add Attendance","Add a New Group"
                                        ,"Add a New Student","Add a New Teacher"
                                        ,"Check a student's attendance percentage"
                                        ,"Get all attendances submitted on a particular day"
                                        ,"Edit Student","Log out"});

                                    Console.Write("\nEnter Choice: ");
                                    int.TryParse(Console.ReadLine(), out optionChosen);

                                    if (optionChosen == 0)
                                    {
                                        DisplayError();
                                    }

                                } while (optionChosen == 0);

                                switch (optionChosen)
                                {
                                    //Add new attendance
                                    case 1:

                                    Console.Clear();

                                    int selectedGroupID = 0;

                                    while (selectedGroupID == 0)
                                    {

                                        MenuMaker("Groups", new List<string> { });

                                        Console.WriteLine("Group ID         Group Name");

                                        List<string> groups = bl.AllGroups();

                                        foreach (var group in groups)
                                        {
                                            Console.WriteLine(group);
                                        }

                                        Console.Write("\nPlease input your selected Group ID: ");

                                        int.TryParse(Console.ReadLine(), out selectedGroupID);

                                        if (selectedGroupID == 0)
                                        {
                                            DisplayError();
                                        }

                                    }

                                    Console.WriteLine(bl.AddLesson(selectedGroupID, DateTime.Now));

                                    Console.WriteLine("\nPress Any Key To Continue");
                                    Console.ReadKey();

                                    Console.Clear();

                                    List<string> studentsInClass = bl.AllStudentsInGroup(selectedGroupID);

                                    MenuMaker("New Attendance",new List<string>());
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
                                    break;

                                    case 2:
                                        //add new group
                                        Console.Clear();

                                        Console.Write("Please input group name: ");
                                        string chosenGroupName = Console.ReadLine();

                                        Console.Write("Please input course name: ");
                                        string chosenCourseName = Console.ReadLine();

                                        Console.Clear();

                                        if (bl.AddGroup(chosenGroupName, chosenCourseName))
                                        {
                                            Console.WriteLine("Successfully added group");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Failed to add group");
                                        }

                                        Console.ReadKey();

                                        break;
                                    case 3:
                                        //add new student
                                        Console.Clear();

                                        Console.Write("Please input group ID: ");
                                        int.TryParse(Console.ReadLine(), out int chosenGroupID);

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
                                            Console.WriteLine("Failed to add student, please be sure that you inputted an existing groupID and filled all fields");
                                        }

                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();

                                        break;
                                    case 4:
                                        //add new teacher
                                        Console.Clear();
                                        
                                        Console.Write("Please input new teacher username: ");
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
                                            Console.WriteLine("\nFailed to add teacher. Please be sure there is " +
                                                              "not an already existing teacher with that username " +
                                                              "and that all fields are filled.");
                                            Console.ReadKey();
                                        }

                                        break;
                                    case 5:
                                        //check attendance percentage
                                        Console.Clear();

                                        Console.Write("Please input student ID: ");

                                        int.TryParse(Console.ReadLine(), out int proposedStudentID);

                                        if(proposedStudentID != 0){

                                            if (bl.VerifyStudentID(proposedStudentID))
                                            {
                                                Console.Clear();

                                                double percentage = bl.ReturnAttendancePercentage(proposedStudentID);

                                                Console.WriteLine("Your Attendance percentage is: " + percentage + "%");

                                                Console.WriteLine("\nPress any key to continue...");
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nNo Student with that ID found.");
                                            }

                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            DisplayError();
                                        }

                                        break;
                                    case 6:
                                        //check attendances on a particular day
                                        MenuMaker("Submitted Attendances",new List<string>());

                                        Console.Write("\nDay: ");
                                        Console.Write("\nMonth: ");
                                        Console.Write("\nYear: ");

                                        Console.SetCursorPosition(5,3);
                                        int.TryParse(Console.ReadLine(), out int day);
                                        Console.SetCursorPosition(7, 4);
                                        int.TryParse(Console.ReadLine(), out int month);
                                        Console.SetCursorPosition(6, 5);
                                        int.TryParse(Console.ReadLine(), out int year);

                                        Console.WriteLine(bl.ReturnAttendancesOnDay(day, month, year));

                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();

                                        break;
                                    case 7:
                                        //edit student
                                        int studentID = 0;

                                        do
                                        {
                                            MenuMaker("Edit Student",new List<string>());

                                            Console.Write("\nStudent ID: ");

                                            Console.SetCursorPosition(12, 3);

                                            int.TryParse(Console.ReadLine(), out studentID);

                                            if (studentID == 0)
                                            {
                                                DisplayError();
                                            }
                                            else
                                            {
                                                if (!bl.VerifyStudentID(studentID))
                                                {
                                                    studentID = 0;
                                                    Console.WriteLine("Student not found, please check student id...");
                                                    Console.ReadKey();
                                                }
                                            }

                                        } while (studentID == 0);

                                        Console.Write("\n Please input Name: ");
                                        string name = Console.ReadLine();

                                        Console.Write("\n Please input Surname: ");
                                        string surname = Console.ReadLine();

                                        Console.Write("\n Please input Email: ");
                                        string email = Console.ReadLine();

                                        Console.Clear();

                                        if (bl.AttemptEditStudent(studentID, name, surname, email))
                                        {
                                            Console.WriteLine("Student successfully edited");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Failed to edit student");
                                        }

                                        Console.WriteLine("\nPress any key to continue...");
                                        Console.ReadKey();
                                        
                                        break;
                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("Password Incorrect.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("The entered ID does not exist in our system.");
                        Console.ReadKey();
                    }

                }
            }
        }

        public static void MenuMaker(string menuName, List<string> menuOptions)
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

        public static void DisplayError()
        {
            Console.Clear();
            Console.WriteLine("Please Input a number, not a letter or special character and make sure all requested inputs are filled.");
            Console.WriteLine("\nPress any key to continue..");
            Console.ReadKey();
        }
    }
}
