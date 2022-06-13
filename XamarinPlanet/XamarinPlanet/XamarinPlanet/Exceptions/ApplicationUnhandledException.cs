using System;

namespace XamarinPlanet
{
    public class ApplicationUnhandledException : Exception
    {
        public ApplicationUnhandledException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}