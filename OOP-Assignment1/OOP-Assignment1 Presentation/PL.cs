using System;
using System.Collections.Generic;
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
                menuMaker("Main Menu",true, menuOptions);
                try
                {
                    Console.Write("Enter Choice: ");
                    userchoice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please Input a number, not a letter or special character.");
                    Console.WriteLine("\nPress any key to continue..");
                    Console.ReadKey();
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
                        if (bl.login(username, password))
                        {
                            //Show teachers Menu


                            while (true)
                            {
                                menuMaker("Teachers Menu", true, new List<string>
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
                                    Console.Clear();
                                    Console.WriteLine("Please Input a number, not a letter or special character.");
                                    Console.WriteLine("\nPress any key to continue..");
                                    Console.ReadKey();
                                }

                                switch (optionChosen)
                                {
                                    case 1:

                                        Console.Clear();

                                        menuMaker("Groups",false,new List<string>{});

                                        List<string> groups = bl.allGroups();

                                        foreach (var group in groups)
                                        {
                                            Console.WriteLine(group);
                                        }

                                        Console.Write("\nPlease input your Group ID: ");
                                        Console.ReadLine();

                                        break;
                                    case 2:
                                        break;
                                    case 3:
                                        break;
                                    case 4:
                                        break;
                                    case 5:
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

        public static void menuMaker(string menuName,bool numbering, List<string> menuOptions)
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
    }
}
