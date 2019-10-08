using System;

namespace ShapesApp.Library
{
    public class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        // not all properties have to be based on one field
        // could be 0, 2, or more

        //ex with 2 fields

        public double Area 
        {
                get
                {
                    return Length * Width;
                }
        }

        //no fields
        public int Dimensions
        {
            get 
            {
                return 2;
            }
        }


        //validation method

        public bool Validate()
        {
            if (Length <= 0)
            {
                return false;
            }
            if (Width <= 0)
            {
                return false;
            }

            return true;
        }


        //interface contract fulfillment
        
        //shorthand for one-line get-only property
        public int Sides => 4;

        public double GetPerimeter()
        {
            return Length * 2 + Width * 2;
        }
    }
}
