using System;

namespace DogApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //fixes scope of the dog.
            Dog dog = null;


            try
            { //put code that may throw an exception

                dog = new Dog("Spot", -5);
            }
            catch (ArgumentOutOfRangeException ex)   //used to fix the exception
            {
                Console.WriteLine("error, recovering from out-of-range exception");
                dog = new Dog("Spot", 5);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("error, recovering from null-argument error");
                dog = new Dog("Spot", 5);
            }


            dog.SetName("Spot");
                
            dog.age = 4;
        }
    }
}
