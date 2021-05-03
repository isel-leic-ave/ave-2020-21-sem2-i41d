using System;
using Xunit;
using Logger;
using System.Text;

namespace Logger.Tests
{
    public class DynamicIGetterInstanceTest
    {
        static DynamicIGetterInstanceCreator dynamicIGetterInstanceCreator = new DynamicIGetterInstanceCreator();

        Student s1 = new Student(154134, "Ze Manel", 5243, "ze");

        [Fact]
        public void TestGenerateIGetterForStudentNumber()
        {
            // Arrange
            IGetter getter = dynamicIGetterInstanceCreator.CreateIGetterFor(typeof(Student), "nr");

            // // Asserts
            Assert.NotNull(getter);
            Assert.Equal("nr", getter.GetName());
            Assert.Equal(s1.nr, (int)getter.GetValue(s1));
        }

        [Fact]
        public void TestGenerateIGetterForStudentName()
        {
            // Arrange
            IGetter getter = dynamicIGetterInstanceCreator.CreateIGetterFor(typeof(Student), "name");

            // // Asserts
            Assert.NotNull(getter);
            Assert.Equal("name", getter.GetName());
            Assert.Equal(s1.name, (string)getter.GetValue(s1));
        }
    }
}
