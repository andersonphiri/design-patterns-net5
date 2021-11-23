using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.After
{
    internal class FixByVisitorPattern
    {
        public void Run()
        {
            var person = new PersonF();
            person.Assets.Add(new BankAccountF { Amount = 1000, MonthlyInterest = 0.01 });
            person.Assets.Add(new BankAccountF { Amount = 2000, MonthlyInterest = 0.02 });
            person.Assets.Add(new RealEstateF { EstimatedValue = 79000, MonthlyRent = 500 });
            person.Assets.Add(new LoanF { Owed = 40000, MonthlyPayment = 40 });
            var networth = new NetworthVisitor();
            var income = new MonthlyIncomeVisitor();
            person.Accept(networth);
            person.Accept(income);
            Console.WriteLine($"Computed Monthly Income: {income.Total} -" +
                $" Computed networth: {networth.Total} ");

        }
    }
    public interface IVisitor
    {
        public void Visit(RealEstateF realEstate);
        public void Visit(BankAccountF bankAccount);
        public void Visit(LoanF loan);
        public int Total { get; }

    }
    public class MonthlyIncomeVisitor : IVisitor
    {
        public int Total { get; private set; }
        public void Visit(RealEstateF realEstate)
        {
            Total += realEstate.MonthlyRent;
        }

        public void Visit(BankAccountF bankAccount)
        {
            Total += bankAccount.Amount;
        }

        public void Visit(LoanF loan)
        {
            Total -= loan.MonthlyPayment;
        }
    }

    public class NetworthVisitor : IVisitor
    {
        public int Total { get; private set; } = 0;

        public void Visit(RealEstateF realEstate)
        {
            Total += realEstate.EstimatedValue;
        }

        public void Visit(BankAccountF bankAccount)
        {
            Total += bankAccount.Amount;
        }

        public void Visit(LoanF loan)
        {
            Total += loan.Owed;
        }
    }

    public interface IVisited
    {
        public void Accept(IVisitor visitor);
    }
    public class PersonF : IVisited
    {
        public IList<IVisited> Assets = new List<IVisited>();

        public void Accept(IVisitor visitor)
        {
            foreach (IVisited visited in Assets) visited.Accept(visitor);
        }
    }
    public class LoanF : IVisited
    {
        public int Owed { get; set; }
        public int MonthlyPayment { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class BankAccountF :  IVisited
    {
        public int Amount { get; set; }
        public double MonthlyInterest { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class RealEstateF : IVisited
    {
        public int EstimatedValue { get; set; }
        public int MonthlyRent { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
