using TestingAssignment;
using System;
using Xunit;

namespace TestingAssignment_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_WordCount()
        {
            //Arrange
            var input = "meet shah";
            var expectedValue = 2;
            // Act
            var result = AssignmentBLL.WordCount(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_NumberValidation()
        {
            //Arrange
            var input = "789";
            var expectedValue = true;
            // Act
            var result = AssignmentBLL.NumberValidation(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_AddLowerCase()
        {
            //Arrange
            var input = "MEET";
            var expectedValue = "meet";
            // Act
            var result = AssignmentBLL.AddLowerCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_AddUpperCase()
        {
            //Arrange
            var input = "meet";
            var expectedValue = "MEET";
            // Act
            var result = AssignmentBLL.AddUpperCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_CheckLowerCase()
        {
            //Arrange
            var input = "do or die";
            var expectedValue = true;
            // Act
            var result = AssignmentBLL.CheckLowerCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_CheckUpperCase()
        {
            //Arrange
            var input = "MEET";
            var expectedValue = true;
            // Act
            var result = AssignmentBLL.CheckUpperCase(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_FirstUpperLetter()
        {
            //Arrange
            var input = "meet";
            var expectedValue = "Meet";
            // Act
            var result = AssignmentBLL.FirstUpperLetter(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_LastCharacterRemove()
        {
            //Arrange
            var input = "meet";
            var expectedValue = "mee";
            // Act
            var result = AssignmentBLL.LastCharacterRemove(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Test_StringToInt()
        {
            //Arrange
            var input = "789";
            var expectedValue = 789;
            // Act
            var result = AssignmentBLL.StringToInt(input);
            //Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
