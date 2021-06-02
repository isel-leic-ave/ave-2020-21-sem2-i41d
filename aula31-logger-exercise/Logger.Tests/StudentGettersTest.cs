using System;
using Xunit;
using Logger;
using System.Text;

namespace Logger.Tests
{
    public class StudentGettersTest
    {
        
        Student s1 = new Student(154134, "Ze Manel", 5243, "ze");

        [Fact]
        public void TestStudentNumberGetter()
        {
            // Arrange
            IGetter getter = new StudentNumberGetter();

            // Act and Asserts
            Assert.Equal("nr", getter.GetName());
            Assert.Equal(s1.nr, (int)getter.GetValue(s1));
        }

        [Fact]
        public void TestStudentNameGetter()
        {
            // Arrange
            IGetter getter = new StudentNameGetter();

            // Act and Asserts
            Assert.Equal("name", getter.GetName());
            Assert.Equal(s1.name, (string)getter.GetValue(s1));
        }
    }
}
