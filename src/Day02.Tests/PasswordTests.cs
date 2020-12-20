using Xunit;

namespace Day02.Tests
{
    public class PasswordTests
    {
        [Fact]
        public void ReturnsFalseAsDefault()
        {
            var password = new Password("X");
            Assert.False(password.IsValid());
        }

        [Fact]
        public void ReturnFalseIfPasswordIsNull()
        {
            var password = new Password(": X");
            Assert.False(password.IsValid());
        }

        [Fact]
        public void ReturnFalseIfPolicyIsNull()
        {
            var password = new Password("X: ");
            Assert.False(password.IsValid());
        }

        [Theory]
        [InlineData("1-3 a: abcde")]
        [InlineData("1-3 b: abcde")]
        public void ReturnsTrueIfPasswordMeetsPolicy(string record)
        {
            var password = new Password(record);
            Assert.True(password.IsValid());
        }

        [Theory]
        [InlineData("1-3 b: cdefg")]
        [InlineData("2-3 a: abcde")]
        [InlineData("2-3 a: aaaabcde")]
        [InlineData("2-3 b: abcde")]
        [InlineData("2-3 b: abbbbcde")]
        public void ReturnsFalseIfPasswordDoesNotMeetPolicy(string record)
        {
            var password = new Password(record);
            Assert.False(password.IsValid());
        }
    }
}
