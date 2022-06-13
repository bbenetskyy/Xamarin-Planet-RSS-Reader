using System;

namespace XamarinPlanet
{
    public class GlobalLogger : ILogger
    {
        public void LogError(Exception ex)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(ex.Message);
            System.Diagnostics.Debug.WriteLine(ex.StackTrace);
#else
            //connect AppCenter and write logs for further diagnostics
#endif
        }

        public void LogDebugMessage(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(message);
#endif
        }
    }
}