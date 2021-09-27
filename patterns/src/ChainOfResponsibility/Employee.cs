using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class Employee : IExpenseApprover
    {
        private readonly decimal _approvalLimit;
        public Employee(string name, decimal approvalLimit)
        {
            Name = name;
            _approvalLimit = approvalLimit;
        }

        public string Name { get; private set; }


        public ApproveResponse ApproveExpense(IExpenseReport expenseReport)
                => expenseReport.Total > _approvalLimit ?
             ApproveResponse.BeyondApprovalLimit : ApproveResponse.Approved;

    }
}
