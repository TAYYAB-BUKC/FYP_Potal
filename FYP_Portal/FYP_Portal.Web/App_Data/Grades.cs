using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem
{
    public class Grades
    {
        public static string grade;
        public static double CGPA; 
        public static string CalculateGrade(double marks)
        {
            //Grade A = 87 - 100    Grade B+ = 80 - 86
            //Grade B = 72 - 79     Grade C+ = 66 - 71
            //Grade C = 60 - 65     Grade D = 50 - 59
            //Grade F = 0 - 49
            //main aata hun thori dair main
            if (marks >= 87)
            {
                return grade="A";
            }
            else if(marks >= 80 && marks <= 86)
            {
                return grade = "B+";
            }
            else if (marks >= 72 && marks <= 79)
            {
                return grade = "B";
            }
            else if (marks >= 66 && marks <= 71)
            {
                return grade = "C+";
            }
            else if (marks >= 60 && marks <= 65)
            {
                return grade = "C";
            }
            else if (marks >= 50 && marks <= 59)
            {
                return grade = "D";
            }
            else
            {
                return grade = "F";
            }


        } 

        public static double CalculateCGPA(string grade)
        {
            switch (grade)
            {
                case "A":
                    CGPA = 4.00;
                    break;
                case "B+":
                    CGPA = 3.50;
                    break;
                case "B":
                    CGPA = 3.00;
                    break;
                case "C+":
                    CGPA = 2.50;
                    break;
                case "C":
                    CGPA = 2.00;
                    break;
                case "D":
                    CGPA = 1.50;
                    break;
                case "F":
                    CGPA = 0.00;
                    break;
            }

            return CGPA;
        }
    }
}
