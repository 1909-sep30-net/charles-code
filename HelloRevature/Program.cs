using System;
using System.Collections.Generic;

namespace HelloRevature
{
    class Program
    {
        static void Main(string[] args)
        {

            
            int mills = Math.Abs( (int) (( DateTimeOffset.Now.ToUnixTimeMilliseconds() % 256) * Math.PI) ) ;
            Random rand = new Random(mills);
            int random = rand.Next(1, 16  );

            Console.WriteLine($"TIme is now { mills} and Random is now : {random }");

            char[] hexVal = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            string stringID = "";

            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(10,"A");
            dict.Add(11,"B");
            dict.Add(12,"C");
            dict.Add(13,"D");
            dict.Add(14,"E");
            dict.Add(15,"F");

            for(int i = 0 ; i <= 15 ; i++)
            {
                random = rand.Next(0, 15  );
                if(random <= 9)
                {
                    stringID += random.ToString();
                }
                else
                {
                    stringID += dict[random];
                }

            }

            Console.WriteLine($"The Code is : { stringID }...");
                
            Console.WriteLine( DateTime.Now.ToString() ) ;
            


        }
    }
}
