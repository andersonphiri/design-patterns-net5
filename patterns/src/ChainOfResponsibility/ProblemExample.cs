using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class ProblemExample
    {
        public void ProblemDemo()
        {
            var employees = new List<Employee> {
            
                new ("A",0m), new("B", 1000m), new("C", 3000m), new("D", 6000m)
            };
            IExpenseReport report = new ExpenseReport(3200m);
            foreach (var emp in employees)
            {
                if (emp.ApproveExpense(report) == ApproveResponse.Approved)
                {
                    Console.WriteLine($"Approved by: {emp.Name}");
                    return;
                }
            }
            Console.WriteLine("Your expense could not be approved");
        }
    }
}
