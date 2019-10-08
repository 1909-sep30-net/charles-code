using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Deligates
{
    class MoviePlayer
    {
        public MoviePlayer CurrentMovie { get; set }

        //events are entities that work on a publish subscribe idea.  Can be published, and many subscribers listen.
        // C# lets you subscribe event handler edelegates to events.
        // what kind of method will be the event handler???

        //the type for handling the event:

        public delegate void MovieFinishedHandler();
        //defines a delegate tyope for void-return and zero-parameters.
        // this describes the shape of functions that can subscribe to this event i'm about to define.

        // the event member, one distinct event per instance of this class
        //(events always a members of a class)
        public event MovieFinishedHandler MovieFinished;

        public void PlayMovie()
        {
            Console.WriteLine($"Playering {CurrentMovie}");

            //Mmovie plays... placeholder code here
            Thread.Sleep(3000); //wait for 3 seconds

            //fire the event. (the syntax looks just like calling a method)
            //what is effectively does is call all the subscribing delegates

            //if there are no subscribers, the event is null.
            //if (MovieFinished != null)
            //{ 
            //    MovieFinished();
            //}

            //better way

            MovieFinished?.Invoke(); // better, modern: do nothing if no subscribers...

        }



    }
}
