using LibsAndTests.Lib1;
using FluentAssertions;
using Xunit;

namespace LibsAndTests.Tests1
{
    public class AdditionServiceTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(10, 20, 30)]
        [InlineData(5, 2, 7)]
        public void it_adds(int a, int b, int c)
        {
            // Assemble
            var s = new AdditionService();

            // Act
            var result = s.Add(a, b);

            // Assert
            result.Should().Be(c);
        }
    }
}