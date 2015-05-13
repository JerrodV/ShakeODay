using System;

namespace ShakeOfTheDay
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (ShakeOfTheDay game = new ShakeOfTheDay())
            {
                game.Run();
            }
        }
    }
#endif
}

