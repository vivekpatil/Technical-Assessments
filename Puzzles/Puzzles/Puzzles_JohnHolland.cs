using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles
{
    public class Puzzles_JohnHolland
    {
        static void Main(string[] args)
        {
            Puzzle1();
            Puzzle2();
            Puzzle3();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void Puzzle1()
        {
            int iFifthElement;
            try
            {
                int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
                iFifthElement = fnReturnFifthElement(numbers);
                Console.WriteLine("The fifth element from tail is: " + iFifthElement);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Array does not have 5th element from tail");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while fetching the fifth element in the array");
                Console.WriteLine("Error Details: " + ex.Message);
            }
        }

        public static int fnReturnFifthElement(int[] numbers)
        {
            //return the fifth element from tail
            return numbers[numbers.Length - 5];
        }

        
        private static void Puzzle2()
        {
            string strTriangleType = string.Empty;
            Double sideA=10, sideB=10, sideC=10;
            bool isTriangle = fnCheckIfTriangle(sideA, sideB, sideC);
            //If its a valid triangle
            if(isTriangle)
            {
                strTriangleType = fnReturnTriangleType(sideA, sideB, sideC);
                Console.WriteLine("The triangle is: " + strTriangleType);
            }
            else
            {
                Console.WriteLine("Error: Triangle cannot be formed based on the sides provided");
            }
        }

        public static string fnReturnTriangleType(double sideA, double sideB, double sideC)
        {
            //All three sides are of same length
            if ((sideA == sideB) && (sideA == sideC))
            {
                return "Equilateral";
            }//If two sides are equal
            else if ((sideA == sideB) || (sideA == sideC) || (sideB == sideC))
            {
                return "Isosceles";
                
            }
            else
            {
                return "Scalene";
            }
        }

        public static bool fnCheckIfTriangle(double sideA, double sideB, double sideC)
        {
            //Below is general principal of triangle
            if((sideA + sideB >= sideC) && (sideB + sideC >= sideA) && (sideA + sideC >= sideB))
                return true;
            return false;
        }

        
        private static void Puzzle3()
        {
            string strStatement = "cat and dog";
            Console.WriteLine("The reversed words: " + fnReverseWords(strStatement));
        }

        public static string fnReverseWords(string strStatement)
        {
            try
            {
                string returnStatement = string.Empty;
                string strTemp = string.Empty;
                //Get cat
                strTemp = strStatement.Substring(0, strStatement.IndexOf(" "));
                //Reverse strTemp
                for (int i = strTemp.Length - 1; i >= 0; i--)
                    returnStatement += strTemp[i];

                returnStatement += " ";
                //Get and
                strTemp = strStatement.Substring(strStatement.IndexOf(" ") + 1, strStatement.LastIndexOf(" ") - strStatement.IndexOf(" ") - 1);
                //Reverse strTemp
                for (int i = strTemp.Length - 1; i >= 0; i--)
                    returnStatement += strTemp[i];

                returnStatement += " ";
                //Get dog
                strTemp = strStatement.Substring(strStatement.LastIndexOf(" ") + 1, strStatement.Length - strStatement.LastIndexOf(" ") - 1);
                //Reverse strTemp
                for (int i = strTemp.Length - 1; i >= 0; i--)
                    returnStatement += strTemp[i];

                return returnStatement;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured when reversing the words, Error details as below");
                return ex.Message.ToString();
            }
        }
    }
}
