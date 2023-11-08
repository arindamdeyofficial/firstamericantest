namespace Logging
{
    public interface ILoggerHelper
    {
        void LogInfo(string msg);
        void LogError(string msg);

        void LogError(Exception msg);
    }
}