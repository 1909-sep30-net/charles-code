using System;

namespace ShapesApp.Library
{
    public class Circle : IShape
    {

        //constructors have no return type adn name is same as class

        public Circle(double radius)
        {
            Radius = radius;
        }
        public int Dimensions => 2;
        public int Sides => 0;

        public double Area => Math.PI * Radius;

        public double Radius { get; set; }
        public double GetPerimeter() => 2* Math.PI * Radius;
    }
}