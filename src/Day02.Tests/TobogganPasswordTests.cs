using Xunit;

namespace Day02.Tests
{
    public class TobogganPasswordTests
    {
        [Fact]
        public void ReturnsFalseAsDefault()
        {
            var password = new TobogganPassword("X");
            Assert.False(password.IsValid());
        }

        [Fact]
        public void ReturnFalseIfPasswordIsNull()
        {
            var password = new TobogganPassword(": X");
            Assert.False(password.IsValid());
        }

        [Fact]
        public void ReturnFalseIfPolicyIsNull()
        {
            var password = new TobogganPassword("X: ");
            Assert.False(password.IsValid());
        }

        [Theory]
        [InlineData("1-3 a: axxxx")]
        [InlineData("2-3 a: xaxxx")]
        [InlineData("2-4 a: xxxax")]
        [InlineData("2-5 a: xxxxa")]
        [InlineData("1-3 a: xxaxx")]
        [InlineData("1-3 a: xaaaa")]
        [InlineData("1-3 b: bxxxx")]
        [InlineData("2-3 c: xcxxx")]
        [InlineData("2-4 d: xxxdx")]
        [InlineData("2-5 e: xxxxe")]
        [InlineData("1-3 f: xxfxx")]
        [InlineData("1-3 g: xgggg")]
        [InlineData("1-3 c: cxxxx")]
        [InlineData("1-3 d: xxdxx")]
        public void ReturnsTrueIfPasswordMeetsPolicy(string record)
        {
            var password = new TobogganPassword(record);
            Assert.True(password.IsValid());
        }

        [Theory]
        [InlineData("1-3 a: xxxxx")]
        [InlineData("1-3 a: xxxxxa")]
        [InlineData("1-3 a: axaxxxx")]
        [InlineData("5-7 a: xxxxaxa")]
        [InlineData("5-7 a: xxxx")]
        public void ReturnsFalseIfPasswordDoesNotMeetPolicy(string record)
        {
            var password = new TobogganPassword(record);
            Assert.False(password.IsValid());
        }
    }
}
