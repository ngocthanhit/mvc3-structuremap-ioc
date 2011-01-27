using System;

namespace SampleWebsite.Code
{
    public class Logger : ILogger
    {
        public void LogMessage(string message)
        {
            //Put some logging logic here, yo.
        }
    }

    public interface ILogger
    {
        void LogMessage(string message);
    }
}