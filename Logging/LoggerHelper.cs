namespace Logging
{
    public class LoggerHelper: ILoggerHelper
    {
        public void LogInfo(string msg)
        {
            Console.WriteLine(msg);
        }
        public void LogError(string msg)
        {
            Console.WriteLine(msg);
        }

        public void LogError(Exception msg)
        {
            Console.WriteLine(msg.StackTrace + Environment.NewLine + msg.Message);
        }
    }
}