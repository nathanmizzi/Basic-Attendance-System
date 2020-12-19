using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int userchoice = 0;
            string username = string.Empty;
            List<string> menuOptions = new List<string>();
            menuOptions.AddRange(new List<string> { "Login", "Exit" });

            while (userchoice != 2)
            {
                menuMaker("Main Menu","=========",menuOptions);
                userchoice = Convert.ToInt32(Console.ReadLine());

                if (userchoice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Login\n=====\n");
                    Console.Write("Username: ");
                    username = Console.ReadLine();

                    //Check if username already exists in the system
                }
            }
        }

        public static void menuMaker(string menuName, string menuSubheading ,List<string> menuOptions)
        {
            int cnt = 0;
            Console.Clear();
            Console.WriteLine(menuName + "\n" + menuSubheading);
            foreach (string menuOption in menuOptions)
            {
                cnt++;
                Console.WriteLine(cnt + ". " + menuOption);
            }
            Console.Write("Enter Choice: ");
        }
    }
}
