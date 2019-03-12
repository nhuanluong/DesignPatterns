using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new SavingsAcctFactory() as ICreditUnionFactory;
            var CitiAcct = factory.GetSavingsAccount("CITI-321");
            var nationalAcct = factory.GetSavingsAccount("NATIONAL-987");

            Console.WriteLine($"My citi balance is ${CitiAcct.Balance}" +
                $" and national balance is ${nationalAcct.Balance}");

            Console.ReadKey();
        }
    }

    public abstract class ISavingsAccount
    {
        public decimal Balance { get; set; }
    }

    public class CitiSavingsAcct : ISavingsAccount
    {
        public CitiSavingsAcct()
        {
            Balance = 5000;
        }
    }

    public class NationalSavingsAcct : ISavingsAccount
    {
        public NationalSavingsAcct()
        {
            Balance = 2000;
        }
    }

    //creator
    interface ICreditUnionFactory
    {
        ISavingsAccount GetSavingsAccount(string acctNo);
    }

    //conrete creators
    public class SavingsAcctFactory : ICreditUnionFactory
    {
        public ISavingsAccount GetSavingsAccount(string acctNo)
        {
            if (acctNo.Contains("CITI")) { return new CitiSavingsAcct(); }
            else
            if (acctNo.Contains("NATIONAL")) return new NationalSavingsAcct();
            else
                throw new ArgumentException("Invalid Account number");
        }
    }
}

