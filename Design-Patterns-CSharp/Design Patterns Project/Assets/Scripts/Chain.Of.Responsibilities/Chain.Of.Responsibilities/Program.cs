using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain.Of.Responsibilities
{
    class Program
    {
        static void Main(string[] args)
        {
            Approver larry = new Director();
            Approver sam = new VicePresident();
            Approver tammy = new President();

            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);

            Purchase p = new Purchase(2034, 350.00, "Supplies");
            larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            larry.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            larry.ProcessRequest(p);

            Console.ReadKey();
        }
    }

    public abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }

    public class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    public class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    public class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine("Request# {0} requires an executive meeting!", purchase.Number);
            }
        }
    }

    public class Purchase
    {
        int number;
        double amount;
        string purpose;

        public Purchase(int number, double amount, string purpose)
        {
            this.number = number;
            this.amount = amount;
            this.purpose = purpose;
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }
    }
}
