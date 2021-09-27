using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class FixProblem
    {
        public ApproveResponse SolutionOneExample()
        {
            ExpenseHandler a = new(new Employee("A", decimal.Zero));
            ExpenseHandler b = new(new Employee("B", 1000m));
            ExpenseHandler c = new(new Employee("C", 3000m));
            ExpenseHandler d = new(new Employee("D", 7000m));

            // Register chain of responsibility
            a.RegisterNext(b);
            b.RegisterNext(c);
            c.RegisterNext(d);

            // The run approve process
            IExpenseReport expense = new ExpenseReport(1500m);
            ApproveResponse response = a.Approve(expense);

            return response;
        }
    }
}
