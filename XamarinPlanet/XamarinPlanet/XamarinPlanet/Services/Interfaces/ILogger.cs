using System;

namespace XamarinPlanet
{
    public interface ILogger
    {
        void LogError(Exception ex);
        void LogDebugMessage(string message);
    }
}