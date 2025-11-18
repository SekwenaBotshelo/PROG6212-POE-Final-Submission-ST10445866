using Xunit;

namespace xUnit_Test
{
    public class SimpleTests
    {
        [Fact]
        public void Test1_OnePlusOneEqualsTwo()
        {
            // Arrange
            int a = 1;
            int b = 1;

            // Act
            int result = a + b;

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test2_StringContains()
        {
            // Arrange
            string testString = "Hello World";

            // Act & Assert
            Assert.Contains("Hello", testString);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test3_TheoryExample(int number)
        {
            // This tests multiple inputs
            Assert.True(number > 0);
        }
    }
}