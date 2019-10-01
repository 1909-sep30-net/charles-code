using System;

namespace CSharpIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");*/

            //make bool, string, and int variables with values
            
            //Charlie: Set some variables, print, change, print again!
            bool isTrue = true;
            string someString = "This is a string";
            int someInt = 42;
            
            Console.Write("Is True? " + isTrue.ToString() + "\nsomeString = " + someString + "\nSome integer is " + someInt.ToString() + "\n");
            
            
            //change their values

            isTrue = false;
            someString = "This was changed";
            someInt++;

            //print their values with console
            Console.WriteLine("The values were changed!\n");
            Console.Write("Is True? " + isTrue.ToString() + "\nsomeString = " + someString + "\nSome integer is " + someInt.ToString() + "\n");
            
            //do something in a for loop
            
            //Charlie: Count to 5.
            for(int i = 0 ; i < 6 ; i++)
            {
                Console.WriteLine(i.ToString() );
            }

            //do something in a while loop
            //Charlie: count to 100 from 10
            int counter = 10;
            while(true)
            {
                counter = counter + 1;
                if(counter > 100)
                {
                    break;
                }
                Console.Write(counter.ToString() + ", ");
            }
            Console.Write("\n");

            //do somethign with a switch statement.

            //Charlie: input to int, then via switch-case, to string output

            int month = 5;

            Console.WriteLine("Enter a number, and I'll tell you what month it is!: ");
 
            string strInt = Console.ReadLine();

            month = Int32.Parse( strInt );
            
            Console.WriteLine("You entered " + month.ToString() );

            if(month > 12)
                month = 12;
            else if(month <1)
                month = 1;
            else
            {
                /*
                Make no adjustments.
                Yes, this is a mutli-line comment example
                 */;
            }

            Console.Write("\nVia switch-case, the month is :");
            switch(month)
            {
                     case 1 : 
                        Console.WriteLine("Janruary");
                        break;
                     case 2 : 
                        Console.WriteLine("February");
                        break;
                     case 3 : 
                        Console.WriteLine("March");
                        break;
                     case 4 : 
                        Console.WriteLine("April");
                        break;
                     case 5 :
                        Console.WriteLine("May");
                        break;
                     case 6 : 
                        Console.WriteLine("June");
                        break;
                     case 7 : 
                        Console.WriteLine("July");
                        break;
                     case 8 : 
                        Console.WriteLine("August");
                        break;
                     case 9 : 
                        Console.WriteLine("September");
                        break;
                     case 10 : 
                        Console.WriteLine("October");
                        break;
                     case 11 : 
                        Console.WriteLine("November");
                        break;
                     case 12 : 
                        Console.WriteLine("December");
                        break;

                     default : 
                        Console.WriteLine("undefined");
                        break;
            }
            //end program

            print("This is a static call to a simple print-method.  Yep, like the print you find in Pythyon!");

            var genericVar = 234.56;

            print("A generic var variable with no specified data type is " + genericVar.ToString() );
        }

        static void print(string theString)
        {
            Console.WriteLine(theString);
        }
    }
}
