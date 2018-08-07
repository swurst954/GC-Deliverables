using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Part1MathChallenge
{
    class Program
    {
        static void Main(string[] args) //used to read numbers
        {
            //The line explains the program and the second line asks the user for the first #
            Console.WriteLine("This program checks if each corresponding place in two numbers (ones, tens, and hundreds) sums to the same total");
            Console.WriteLine("Enter a four digit number.");

            var firstNumber = Console.ReadLine();

            while (firstNumber.Length != 4) //This explains to the user that the incorrect # of digits were inputted
            {
                Console.WriteLine("Incorrect # of digits, try again.");
                firstNumber = Console.ReadLine();
            }

            Console.WriteLine("Enter another four digit number."); //user to input second #
            var secondNumber = Console.ReadLine();

            while (secondNumber.Length != 4) //This explains to the user that the incorrect # of digits were inputted
            {
                Console.WriteLine("Incorrect # of digits, try again.");
                secondNumber = Console.ReadLine();
            }

            Numbers newNumber = new Numbers();
            newNumber.GetNumbers(firstNumber, secondNumber);

            Console.ReadKey();
        }
    }

    class Numbers
    {

        public void GetNumbers(string firstNumber, string secondNumber)
        {
            // The three-digit numbers is now changed from variables to integers.
            int number1 = int.Parse(firstNumber.ToString());
            int number2 = int.Parse(secondNumber.ToString());

            List<int> list1 = new List<int>();  // The strings are divided into lists of integers.
            while (number1 > 0)
            {
                int digit;
                number1 = Math.DivRem(number1, 10, out digit);
                list1.Add(digit);
            }
            list1.Reverse();

            List<int> list2 = new List<int>();
            while (number2 > 0)
            {
                int digit2;
                number2 = Math.DivRem(number2, 10, out digit2);
                list2.Add(digit2);
            }
            list2.Reverse();

            int[] Array1 = list1.ToArray(); // The integer lists are divided into Int[]s.
            int[] Array2 = list2.ToArray();

            var List3 = Enumerable.Zip(Array1, Array2, (a, b) => a + b); // Arrays are added together to form third Array.
            int[] Array3 = List3.ToArray();

            if (Array3[0] == Array3[1] && //Array3 is compared and the output = True/False
                Array3[0] == Array3[2] &&
                Array3[0] == Array3[3])
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}