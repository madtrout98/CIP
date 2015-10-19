using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGradebook
{
    public class Program
    {
        static string studentNames;
        static int score;
        static string letterGrade;
        static double averageScore;
        static string inputTestScore;
        static int testScore;
        static string startMenu;
        static string path;

        static void Main(string[] args)
        {
            //These are my separate classes used to help organize my code.
            InitialStart();
            Scores();
        }
        static void InitialStart()
        {
            Console.WriteLine("Enter 'input' to add a new student to the registry.\nEnter 'past student' to get information about a student previously entered. Enter 'quit' to exit the program.");
            startMenu = "";
            startMenu = Console.ReadLine();
            startMenu.ToLower(); //Making sure to be lowercased. 

            if (startMenu == "past student")
            {
                string[] printEntries = File.ReadAllLines("\\server/student_docs$/mstrout/Visual Studio 2015/Projects/gradebook/StudentInformation.txt");
                Console.WriteLine("");
                foreach (string line in printEntries)
                {
                    Console.WriteLine(line);
                }
                Console.ReadLine();
            }
            else if (startMenu == "input")
            {
                Console.WriteLine("\nPlease input the name of the student starting with their last name, then first. \n\nLike so: LN,FN");
                studentNames = Console.ReadLine();
            }
        }
        static void Scores()
        {
            while (inputTestScore != "done")
            {
                Console.WriteLine("Please input the scores of tests taken and type 'complete' when finished adding scores.");
                inputTestScore = Console.ReadLine();
                inputTestScore = inputTestScore.ToLower();

                if (inputTestScore == "complete")
                {
                    double sumTest = scores.Sum();
                    averageScore = sumTest / scores.Count; //Is score wrong to use? Is that causing he trouble? 
                    Console.WriteLine(Convert.ToString(averageScore));
                    String.Format("{0:0.00}", averageScore); //Explain the double and sum?

                    FindGrade(averageScore); //Here is where the major issue keeps happening. This is not being utilized. 
                    Console.WriteLine("\n" + "Student's Name is: " + studentNames);
                    Console.WriteLine("Number of tests taken is: " + scores.Count); //This is always '0'.
                    Console.WriteLine("Average test score is " + averageScore); //This had a weird 'NaN' thing what is that?
                    Console.WriteLine("Student's overall grade is: " + letterGrade);
                    Console.ReadLine();
                    CreateEntry();
                    inputTestScore = "";
                    break;

                }
                else
                {
                    testScore = Int32.Parse(inputTestScore);
                    scores.Add(testScore);
                }
        
            }
        }

        public static string FindGrade(double averageScore) //Here is where the averages are tallied and placed into the letter grade ranges.
        {
            if (averageScore >= 90)
            {
                letterGrade = "A";
            }
            else if (averageScore >= 85)
            {
                letterGrade = "B";
            }
            else if (averageScore >= 75)
            {
                letterGrade = "C";
            }
            else if (averageScore >= 65)
            {
                letterGrade = "D";
            }
            else if (averageScore <= 60)
            {
                letterGrade = "F";
            }
            return letterGrade;
        }
            static void CreateEntry()
        {
            path = "\\server/student_docs$/mstrout/Visual Studio 2015/Projects/gradebook/StudentInformation.txt";
                if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path)) //What's this? Why doesn't it work now 'StreamWriter' doesn't exist. My gracious.?
                {
                    sw.WriteLine("Student Name: " + studentNames);
                    sw.WriteLine("Tests Taken: " + testScore);
                    sw.WriteLine("Average Score: " + averageScore);
                    sw.WriteLine("Letter Grade: " + letterGrade);
                    sw.WriteLine("");
                }

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("Student Name: " + studentNames);
                    sw.WriteLine("Tests Taken: " + scores.Count);
                    sw.WriteLine("Average Score: " + averageScore);
                    sw.WriteLine("Letter Grade: " + letterGrade);
                    sw.WriteLine("");
                }
            }
        }
        public static List<double> scores = new List<double>();
    }
}
