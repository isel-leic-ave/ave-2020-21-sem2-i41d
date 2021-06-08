using System;
using Xunit;
using Logger;
using System.Text;

namespace Logger.Test
{
    public class LogTest
    {

        [Fact]
        public void TestLogPoint()
        {
            Point p = new Point(7, 9);
            BufferPrinter printer = new BufferPrinter();
            Log log = new Log(printer);
            log.Info(p);
            Assert.Equal(
                "Point{x:7}", 
                printer.buffer.ToString());
        }
    }
}
