using LibsAndTests.Lib2;
using FluentAssertions;
using Xunit;

namespace LibsAndTests.Tests2
{
    public class ConcatServiceTests
    {
        [Theory]
        [InlineData("a", "b", "ab")]
        [InlineData("hello", " world", "hello world")]
        [InlineData("hello ", "world", "hello world")]
        public void it_concats(string a, string b, string c)
        {
            // Assemble
            var s = new ConcatService();

            // Act
            var result = s.Concat(a, b);

            // Assert
            result.Should().Be(c);
        }
    }
}