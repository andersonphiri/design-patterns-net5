using System;

namespace ChainOfResponsibility
{
    public interface IExpenseHandler
    {
        ApproveResponse Approve(IExpenseReport expenseReport);
        void RegisterNext(IExpenseHandler next);
    }
    public class ExpenseHandler : IExpenseHandler
    {
        private readonly IExpenseApprover _approver;
        private IExpenseHandler _next;

        public ExpenseHandler(IExpenseApprover expenseApprover)
        {
            _approver = expenseApprover;
            _next = EndOfChainExpenseHandler.Instance;
        }
        public ApproveResponse Approve(IExpenseReport expenseReport)
        {
            var response = _approver.ApproveExpense(expenseReport);
            if (response == ApproveResponse.BeyondApprovalLimit)
            {
                return _next.Approve(expenseReport);
            }
            return response;
        }

        public void RegisterNext(IExpenseHandler next)
        {
            _next = next;
        }

    }
    public class EndOfChainExpenseHandler : IExpenseHandler
    {
        private EndOfChainExpenseHandler()
        {

        }
        public ApproveResponse Approve(IExpenseReport expenseReport)
        {
            return ApproveResponse.Denied;
        }
        public static EndOfChainExpenseHandler Instance { get => _instance;  }

        public void RegisterNext(IExpenseHandler next)
        {
            throw new InvalidOperationException("End of chain handler must be end of chain!");
        }

        private static readonly EndOfChainExpenseHandler _instance = new();
    }
}
