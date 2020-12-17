using System.Collections.Generic;
using System.Linq;

namespace Day01
{
    public class ExpenseReport
    {
        private IEnumerable<int> _expenses;

        public void SetExpenses(IEnumerable<int> expenses)
        {
            _expenses = expenses;
        }

        public int Fix()
        {
            if (_expenses is null) return 0;
            var itemCount = _expenses.Count();
            for (int i = 0; i < itemCount; i++)
            {
                var baseExpense = _expenses.ElementAt(i);
                for (int j = 0; j < itemCount; j++)
                {
                    if (i == j) continue;
                    if (baseExpense + _expenses.ElementAt(j) == 2020)
                        return baseExpense * _expenses.ElementAt(j);
                }
            }

            return 0;
        }
    }
}
