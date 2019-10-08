using System;

namespace Deligates
{
    class Program
    {
        static void Main(string[] args)
        {
            var movie = "Frozen";

            var moviePlayer = new MoviePlayer {CurrentMovie = movie };

            // this implicit conversion works because themethod has the right shape.

            MoviePlayer.MovieFinishedHandler handler = PrintMovieOver;

            moviePlayer.MovieFinished += handler;
        
            MoviePlayer.PlayMovie();


        }
    }

    static void PrintMovieOver()
    {
        Console.WriteLine("Movie Finished");
    }


}
