/* 
Collections
August, 2019 Charles Allensworth
A study of arrays and other data-structures in C#.

 */

using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Arrays();

        }

        static void Arrays()
        {
            //arrays are most basic way to group many values of same data-type together.
            //arrays not used much anymore, and is often the "wrong" type of data-structure.  This
            //is often due to inflexible size.  Are, though, the fastest way to store and get data.
            //all data types have a default.

            //auto-initialized with zero each cell.
            int[] intArray = new int[4];

            intArray[0] = 3;
            intArray[0] = 5;

            //intArray now 3,5,0,0 for values.

            //Another way is called "collection initiization"
            // The numbers in the curley brackets are the collection.
                                        //collection
            int[] intArray2 = new int[] { 1, 2, 3, 4, 12 };

            //console input from user.

            Console.WriteLine("Enter an array's length");
            string input = Console.ReadLine();
            int length = int.Parse(input);
            int[] array3 = new int[length];

            //more than one ways to do arrays
            //jagged arrays, arrays of arrays.
            int[][] twoD = new int [3][];
            twoD[0] = new int[] { 1 , 2 };
            twoD[1] = new int[] { 1, 2, 3 };

            //true Multi-DImentional Arrays in C#
            int[,] twoDMulti = new int [3,5];

            twoDMulti[0, 0] = 3; // specify row and column.

            //Doing initialized array
            int [,,]threeDArray = new int [3, 3,3];


       }
    }
}
