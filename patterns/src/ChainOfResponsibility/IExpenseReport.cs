using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public interface IExpenseReport
    {
        decimal Total { get; }
    }
    public interface IExpenseApprover
    {
        ApproveResponse ApproveExpense(IExpenseReport expenseReport);
    }
    public enum ApproveResponse
    {
        Denied,
        Approved,
        BeyondApprovalLimit,
    }
}
