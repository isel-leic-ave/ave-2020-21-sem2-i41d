using System;
using Xunit;
using Logger;
using System.Text;

namespace Logger.Test
{
    public class LogDynamicTest
    {

        [Fact]
        public void TestLogPoint()
        {
            Point p = new Point(7, 9);
            BufferPrinter printer = new BufferPrinter();
            LogDynamic log = new LogDynamic(printer);
            log.Info(p);
            Assert.Equal(
                "Point{x:7}", 
                printer.buffer.ToString());
        }

        [Fact]
        public void TestDynamicGetterForStudentName()
        {
            //
            // Arrange
            // 
            DynamicGetterBuider builder = new DynamicGetterBuider(typeof(Student));
            Type getterType = builder.GenerateGetterFor(typeof(Student).GetField("name"));
            IGetter getter = (IGetter) Activator.CreateInstance(getterType);
            // builder.SaveModule();
            // 
            // Act
            //
            Student st = new Student(762354, "Ze Manel", 13, "zemanel");
            Assert.Equal("name", getter.GetName());
            Assert.Equal("Ze Manel", getter.GetValue(st));
        }
        [Fact]
        public void TestDynamicGetterForStudentNr()
        {
            //
            // Arrange
            // 
            DynamicGetterBuider builder = new DynamicGetterBuider(typeof(Student));
            Type getterType = builder.GenerateGetterFor(typeof(Student).GetField("nr"));
            IGetter getter = (IGetter) Activator.CreateInstance(getterType);
            // builder.SaveModule();
            // 
            // Act
            //
            Student st = new Student(762354, "Ze Manel", 13, "zemanel");
            Assert.Equal("nr", getter.GetName());
            Assert.Equal(762354, getter.GetValue(st));
        }
    }
}
