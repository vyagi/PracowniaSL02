using System;

namespace DecoratorPattern
{
    public interface ILogger
    {
        string Log(string textToLog);
    }

    public class SimpleLogger : ILogger
    {
        public string Log(string textToLog) => 
            $"Information: {textToLog}";
    }

    public class TimestampingLogger : ILogger
    {
        private ILogger _logger;

        public TimestampingLogger(ILogger logger) => _logger = logger;

        public string Log(string textToLog) => 
            $"{DateTime.Now:yyyy-MM-dd:THH:mm:ss]} {_logger.Log(textToLog)}";
    }

    public class HashingLogger : ILogger
    {
        private ILogger _logger;

        public HashingLogger(ILogger logger) => _logger = logger;

        public string Log(string textToLog) => MD5Hash.Hash.Content(_logger.Log(textToLog));
    }

    // public class Logger
    // {
    //     public virtual string Log(string textToLog) => $"Information: {textToLog}";
    // }
    //
    // public class TimestampingLogger : Logger
    // {
    //     public override string Log(string textToLog) => $"{DateTime.Now:yyyy-MM-dd:THH:mm:ss]} {base.Log(textToLog)}";
    // }
    //
    // public class HashingLogger : Logger
    // {
    //     public override string Log(string textToLog) => 
    //         MD5Hash.Hash.Content(base.Log(textToLog));
    // }
    //
    // public class TimestampingHashingLogger : Logger
    // {
    //     public override string Log(string textToLog) => "";
    // }
    //
    // public class HashingTimestampingLogger : Logger
    // {
    //     public override string Log(string textToLog) => "";
    // }
}
