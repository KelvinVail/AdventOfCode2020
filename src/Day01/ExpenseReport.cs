using System.Collections.Generic;
using System.Linq;

namespace Day01
{
    public class ExpenseReport
    {
        private IList<int> _expenses;

        public void SetExpenses(IEnumerable<int> expenses)
        {
            _expenses = expenses.ToList();
        }

        public int Fix(int errors = 2)
        {
            if (_expenses is null) return 0;

            var expensesToEvaluate = new List<int>();
            for (int i = 0; i < _expenses.Count; i++)
            {
                for (int j = 0; j < _expenses.Count; j++)
                {
                    if (j == i) continue;

                    if (errors > 2)
                    {
                        for (int k = 0; k < _expenses.Count; k++)
                        {
                            if (k == j) continue;
                            expensesToEvaluate.Clear();
                            expensesToEvaluate.Add(_expenses[i]);
                            expensesToEvaluate.Add(_expenses[j]);
                            expensesToEvaluate.Add(_expenses[k]);

                            var result = CalculateError(expensesToEvaluate, 2020);
                            if (result > 0) return result;
                        }
                    }
                    else
                    {
                        expensesToEvaluate.Clear();
                        expensesToEvaluate.Add(_expenses[i]);
                        expensesToEvaluate.Add(_expenses[j]);

                        var result = CalculateError(expensesToEvaluate, 2020);
                        if (result > 0) return result;
                    }
                }
            }

            return 0;
        }

        private static int CalculateError(IList<int> expenses, int target)
        {
            if (expenses.Sum() == target)
                return expenses.Aggregate((x, y) => x * y);
            return 0;
        }
    }
}
