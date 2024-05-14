using System;
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

        [Fact]
        public void Pst()
        {
            // Act
            var actual = PstNow();

            // Assert
            Console.WriteLine($"actual {actual.ToString()}, {actual.Offset}");
            var pstNow = DateTime.UtcNow.AddHours(-7);
            Console.WriteLine($"pstNow  {pstNow.ToString()}, {pstNow.Kind}");
            var pstNowOffset = new DateTimeOffset(DateOnly.FromDateTime(pstNow), TimeOnly.FromDateTime(pstNow),
                TimeSpan.FromHours(-7));
            Console.WriteLine($"pstNowOffset  {pstNowOffset.ToString()}, {pstNowOffset.Offset}");
            var timeDifference = pstNowOffset - actual;
            Assert.InRange(timeDifference.TotalMilliseconds, 0, 50);
        }

        public DateTimeOffset PstNow()
        {
            var tzInfo = TimeZoneInfo.FindSystemTimeZoneById("America/Los_Angeles");
            Console.WriteLine($"ID: {tzInfo?.Id}, offset: {tzInfo?.BaseUtcOffset.TotalHours}");
            var a = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzInfo);
            return new DateTimeOffset(a, TimeSpan.FromHours(-7));
        }
    }
}