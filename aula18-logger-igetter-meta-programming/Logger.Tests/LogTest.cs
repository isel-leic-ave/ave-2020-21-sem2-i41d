using System;
using Xunit;
using Logger;
using System.Text;

namespace Logger.Tests
{

    class BufferPrinter : IPrinter
    {
        public StringBuilder buffer = new StringBuilder();
        public void Print(string output)
        {
            buffer.Append(output);
        }
    }

    public class LogTest
    {
        [Fact]
        public void TestLogInfo()
        {
            // Arrange
            Point p = new Point(7,9);
            BufferPrinter printer = new BufferPrinter();
            Log log = new Log(printer);

            // Act
            log.Info(p);

            // Assert
            Assert.Equal(
                "x: 7, y: 9",
                printer.buffer.ToString()
            );
        }
        [Fact]
        public void TestLogDynamic()
        {
            // Arrange
            Point p = new Point(7,9);
            BufferPrinter printer = new BufferPrinter();
            LogDynamic log = new LogDynamic(printer);

            // Act
            log.Info(p);

            // Assert
            Assert.Equal(
                "x: 7, y: 9",
                printer.buffer.ToString()
            );
        }
    }
}
