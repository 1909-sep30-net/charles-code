using System;

namespace ShapesApp.App
{
    class Program
    {
        static void Main(string[] args)
        {
            

            double length;
            string input;
            do
            {
            Console.WriteLine("Enter a Length");
            input = Console.ReadLine();

            }while(!double.TryParse(input, out length) );
                                        //C# has something called "out" parameters
                                        // an out parameter cannot have a value before you pass it
                                        //the method gets that exact variable and fills in its value
                                        //enables a form of pass-by-reference.

            double width;
            do
            {
            Console.WriteLine("Enter a Width");
            input = Console.ReadLine();

            }while(!double.TryParse(input, out width) );
            
            

            
        }

        //An example of how TryParse works.  We have written our own here.        
        static bool TryParse(string input, out double result)
        {
            try
            {
                result = double.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                result = 0;
                return false;
            }   
        }
    }
}
