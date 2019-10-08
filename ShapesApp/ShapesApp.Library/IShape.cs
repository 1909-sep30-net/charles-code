namespace ShapesApp.Library
{
    //needs to be a public interface so project can see it
    
    public interface IShape
    {
        // an interface is a contract that classes can declare themselves as following
        
        int Dimensions
        {
            get;
        }
        
        int Sides
        {
            get;
        }

        double Area 
        { 
            get; 
        }

        double GetPerimeter();
    }
}