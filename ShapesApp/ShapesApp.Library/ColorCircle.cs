using System;

namespace ShapesApp.Library
{
    public class ColorCircle : Circle
    {

        //constructors are not inherited, and every subclass implicitely calls 1 parent class constructor first.


        //simplified pass to the base-class
        public ColorCircle(double radius) : base( radius)
        {
            //one per child class
            
        }

        public ColorCircle(double radius, string color) : base( radius)
        {
            //one per child class
        }
        

        public ColorCircle( double radius) : this (radius, "clear")
        {
            
        }


        public string Color { get; set; };

        //unsavory version
        public double GetPerimeter()
        {

            


            Console.WriteLine("calculating perimeter");
            return 2 * Math.PI * Radius;
        }

    }
}