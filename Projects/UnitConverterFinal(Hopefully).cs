using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merp
{
    class Program
    {
        public static void Main(string[] args) //Main 
        {
            Start();
            TryAgain();
        }
        public static void Start()
        {

            double cm, i, ft; //Variables are introduced as units.
            Console.Clear();
            Console.WriteLine("\nPlease enter the amount of centimeters you'd like to convert."); //Beginning with centimeters the user is prompted to give the amount being converted. 
            cm = Convert.ToInt32(Console.ReadLine());

            i = cm * 2.54; //Variables are connected to the formulas needed.
            Console.WriteLine("\n This distance taken is " + i + " in inches."); //Conversions are executed here for inches.

            ft = i * 12; //Final variable used, connected to previous conversion so it isn't taking the wrong variable into the formula. 
            Console.WriteLine("\n The distance taken is " + ft + " in feet."); //These conversions are done for feet. 

            Console.ReadLine();

            //Use the 'while' loop technique to continue the code! 
        }

        public static void TryAgain() //Calls upon the 
        {
            Console.WriteLine(" \nWould you like to try again? Y/N?");
            string userValue = "";
            userValue = Console.ReadLine();

            if (userValue.ToUpper() == "Y")
            {
                Start();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
