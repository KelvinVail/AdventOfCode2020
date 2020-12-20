using System.Collections.Generic;
using Xunit;

namespace Day01.Tests
{
    public class ExpenseReportTests
    {
        private readonly ExpenseReport _expenseReport = new ExpenseReport();

        [Fact]
        public void FixReturnsZero()
        {
            Assert.Equal(0, _expenseReport.Fix());
        }

        [Theory]
        [InlineData(1010, 1010)]
        [InlineData(1009, 1011)]
        public void FixReturnsProductOfNumbersThatAddUpTo2020(int one, int two)
        {
            var expenses = new List<int> { one, two };
            _expenseReport.SetExpenses(expenses);

            var result = _expenseReport.Fix();

            Assert.Equal(one * two, result);
        }

        [Theory]
        [InlineData(1, 1)]
        public void FixReturnsZeroIfNumbersDoNotAddUpTo2020(int one, int two)
        {
            var expenses = new List<int> { one, two };
            _expenseReport.SetExpenses(expenses);

            var result = _expenseReport.Fix();

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(1010, 1010, 10, 1010 * 1010)]
        [InlineData(1009, 88, 1011, 1009 * 1011)]
        [InlineData(1010, 1009, 1011, 1009 * 1011)]
        public void FixReturnsProductOfAnyTwoNumbersThatAddUpTo2020(
            int one,
            int two,
            int three,
            int expected)
        {
            var expenses = new List<int> { one, two, three };
            _expenseReport.SetExpenses(expenses);

            var result = _expenseReport.Fix();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(979, 366, 675, 10, 241861950)]
        [InlineData(979, 365, 10, 676, 979 * 365 * 676)]
        public void FixReturnsProductOfAnyThreeNumbersThatAddUpTo2020(
            int one,
            int two,
            int three,
            int four,
            int expected)
        {
            var expenses = new List<int> { one, two, three, four };
            _expenseReport.SetExpenses(expenses);

            var result = _expenseReport.Fix(3);

            Assert.Equal(expected, result);
        }
    }
}
