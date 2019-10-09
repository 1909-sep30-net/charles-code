using System;
using System.Collections.Generic;

namespace shared_reference
{
    public class sampleClass
    {
        public int field1;
        public double field2;
        public string field3;

        public bool field4;

        public char field5;

        public sampleClass(int f1, double f2, string f3, bool f4, char f5)
        {
            this.field1 = f1;
            this.field2 = f2;
            this.field3 = f3;
            this.field4 = f4;
            this.field5 = f5;
        }

        public string GetPrintable()
        {
            return ( field1.ToString() + " " + field2.ToString() + " " + field3 + " "  + field4.ToString() + " " + field5.ToString() );
        }
    } 
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing shared references between two lists.");

            //create an empty list
            List<sampleClass> list1 = new List<sampleClass>();

            //create some class instances
            sampleClass object1 = new sampleClass(42 , 256.00, "DARKSTAR", true, 'X');
            sampleClass object2 = new sampleClass(512 , 15.00, "NEUTRONSTAR", false, 'N');
            sampleClass object3 = new sampleClass(92169 , 4509.00, "VERDANTSTAR", true, 'L');

            //try as a quick add...
            list1.Add(object1);
            list1.Add(object2);
            list1.Add(object3);

            //confirm output

            Console.Out.WriteLine( list1[0].GetPrintable() );
            Console.Out.WriteLine( list1[1].GetPrintable() );
            Console.Out.WriteLine( list1[2].GetPrintable() );
            
            doHR();

            //works, so ... lets see if we can edit from outside the list.

            object1.field3 = "BLACK HOLE";

            //both refer to the same object????
            Console.Out.WriteLine( list1[0].GetPrintable() );
            doHR();
            //Oh yes, yes, they do....
            
            //so lets see if 2 lists will share.

            //create another empty list of the same type.
            //quickly add the 3 objects to the second list.
            List<sampleClass> list2 = new List<sampleClass>() {object3, object2, object1};

            //confirm the order...
            Console.Out.WriteLine( list2[0].GetPrintable() );
            Console.Out.WriteLine( list2[1].GetPrintable() );
            Console.Out.WriteLine( list2[2].GetPrintable() );
            doHR();

            //Now to modify each and every object, we won't use ref here, but will do it manually.
            object1.field1 = 234;
            object1.field2 = 324.056;
            object1.field3 = "SINGULARITY";
            object1.field4 = true;
            object1.field5 = '•';

            //confirm changes to object, which should be reflected in both lists....
            //object1
            Console.Out.WriteLine( object1.GetPrintable() );
            doHR();

            //confirm reference to object1
            Console.Out.WriteLine( list1[0].GetPrintable() );
            doHR();
            //conform yet another reference to object1, also...
            Console.Out.WriteLine( list2[2].GetPrintable() );
            doHR();

            //in conclusion, objects put into a list are PASSED BY REFERENCE.
            //           :)

            //now lets use a method to modify the referenced-object.... in a list.
            //note how we are using a reference
            modifyObject(ref object1 );

            //confirm all changes...
            Console.Out.WriteLine( list1[0].GetPrintable() );
            doHR();
            //conform yet another reference to object1, also...
            Console.Out.WriteLine( list2[2].GetPrintable() );
            doHR();

            //see if we even need to bother with ref

            //new object
            sampleClass object4 = new sampleClass( 35, (double) Math.PI, "🏝️", false, 'D' );
            Console.Out.WriteLine( object4.GetPrintable() );
            doHR();

            //add it to the lists with the no-ref method
            addToBothLists(list1, list2, object4);
            //confirm all changes...
            Console.Out.WriteLine( list1[0].GetPrintable() );
            Console.Out.WriteLine( list1[1].GetPrintable() );
            Console.Out.WriteLine( list1[2].GetPrintable() );
            Console.Out.WriteLine( list1[3].GetPrintable() );
            doHR();

            Console.Out.WriteLine( list2[0].GetPrintable() );
            Console.Out.WriteLine( list2[1].GetPrintable() );
            Console.Out.WriteLine( list2[2].GetPrintable() );
            Console.Out.WriteLine( list2[3].GetPrintable() );
            doHR();

            //see if they are unique objects, or also references.
            modifyObject2(object4);
            Console.Out.WriteLine( object4.GetPrintable() );
            doHR();

            //confirm all changes...
            Console.Out.WriteLine( list1[0].GetPrintable() );
            Console.Out.WriteLine( list1[1].GetPrintable() );
            Console.Out.WriteLine( list1[2].GetPrintable() );
            Console.Out.WriteLine( list1[3].GetPrintable() );
            doHR();

            Console.Out.WriteLine( list2[0].GetPrintable() );
            Console.Out.WriteLine( list2[1].GetPrintable() );
            Console.Out.WriteLine( list2[2].GetPrintable() );
            Console.Out.WriteLine( list2[3].GetPrintable() );
            doHR();

            //which works
            // indicates that ref is not needed at all.... for reference varables
            // and that no matter what, lists take references to objects and are
            // shallow copy.
            //
            // For reference-type variables,
            //    if a pass-by-value is desired, 
            //    a deep-copy method will be required.
            // 1. create the new object of the same class
            // 2. copy all the variables from one object to another
            // 3. put new object into list.



        }

        public static void doHR()
        {
            Console.Out.WriteLine("\n----------------------------\n");
        }

        //simply converts everything to emogee robot info
        public static void modifyObject(ref sampleClass obj)
        {
            obj.field1 = 129302;
            obj.field2 = 129302.0;
            obj.field3 = "HUMAN | 😏🤖 | ROBOT"; //this works, as string decodes Unicode
            obj.field4 = false;
            //won't work, sadly, needs more maths before we can get the unicode character as a char.
            //obj.field5 = 🤖;
            obj.field5 = 'R';

        }

        public static void modifyObject2(sampleClass obj)
        {
            obj.field1 = 9;
            obj.field2 = 4.0;
            obj.field3 = "DESERT ISLAND";
            obj.field4 = false;
            obj.field5 = 'Q';

        }

        public static void addToBothLists( List<sampleClass> listun, List<sampleClass> listdeux, sampleClass obj)
        {
            listun.Add(obj);
            listdeux.Add(obj);

        }

    }
}
