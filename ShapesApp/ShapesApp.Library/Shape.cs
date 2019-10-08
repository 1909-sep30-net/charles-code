//abstracts can have some implimentations of a method that is to be shared, or at least some default values.

namespace ShapesApp.Library
{
    public abstract class TwoDeeShape : IShape
    {
        // in an abstract class, you don't need an implementation for everyything
        //but the subclasses who use the abstract must.
        public int Dimensions => 2;

        public abstract int Sides { get; }
        public abstract double Area{ get; }
        public abstract double GetPerimeter();
    }
}