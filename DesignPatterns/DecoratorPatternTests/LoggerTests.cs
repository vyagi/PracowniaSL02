using System;
using DecoratorPattern;
using FluentAssertions;
using Xunit;

namespace DecoratorPatternTests
{
    public class LoggerTests
    {
        [Fact]
        public void Simple_logger_logs_properly()
        {
            var logger = new SimpleLogger();
            var log = logger.Log("Marcin");
            log.Should().Be("Information: Marcin");
        }

        [Fact]
        public void TimestampingLogger_logs_properly()
        {
            var logger = new TimestampingLogger(new SimpleLogger());
            var log = logger.Log("Marcin");
        
            log.Should().StartWith("2021");
            log.Should().EndWith("Information: Marcin");
        }
        
        [Fact]
        public void HashingLogger_logs_properly()
        {
            var logger = new HashingLogger(new SimpleLogger());
            var log = logger.Log("Marcin");
        
            log.Should().NotContain("Marcin");
        }

        [Fact]
        public void HashingTimestampingLogger_logs_properly()
        {
            var logger = new TimestampingLogger(new HashingLogger(new SimpleLogger()));
            var log = logger.Log("Marcin");

            log.Should().NotContain("Marcin");
            log.Should().StartWith("2021");
        }

        [Fact]
        public void TimestampingHashingLogger_logs_properly()
        {
            var logger = new HashingLogger(new TimestampingLogger(new SimpleLogger()));
            var log = logger.Log("Marcin");

            log.Should().NotContain("Marcin");
            log.Should().NotStartWith("2021");
        }
    }
}
