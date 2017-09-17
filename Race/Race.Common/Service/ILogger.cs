using System;

namespace Race.Common.Service
{
    public interface ILogger
    {
        void Log(Severity level, string text);

        void LogException(Severity level, string text, Exception ex);
    }
}