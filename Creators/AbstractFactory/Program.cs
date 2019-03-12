using System;
using System.Collections.Generic;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> accntNumbers = new List<string>{
                "CITI-456",
                "NATIONAL-897",
                "CHASE-222"
            };

            for (int i = 0; i < accntNumbers.Count; i++)
            {
                ICreditUnionFactory anAbstractFactory = CitiCreditUnionFactoryProvider.GetCreditUnionFactory(accntNumbers[i]);
                if (anAbstractFactory == null)
                {
                    Console.WriteLine("Sorry, This credit union w/ account number"
                    + $" '{accntNumbers[i]}' is invalid.");
                }
                else
                {
                    ILoanAccount loan = anAbstractFactory.CreateLoanAccount();
                    ISavingsAccount savings = anAbstractFactory.CreateSavingsAccount();
                }
            }            
        }
    }

    public abstract class ICreditUnionFactory
    {
        public abstract ISavingsAccount CreateSavingsAccount();
        public abstract ILoanAccount CreateLoanAccount();
    }

    public interface ILoanAccount
    {
    }

    public interface ISavingsAccount
    {
    }

    public class CitiSavingsAccount : ISavingsAccount
    {
        public CitiSavingsAccount()
        {
            Console.WriteLine("Returned Citi Savings Account");
        }
    }

    public class CitiLoanAccount : ILoanAccount
    {
        public CitiLoanAccount()
        {
            Console.WriteLine("Returned Citi Loan Account");
        }
    }

    //Concrete Factory 1
    public class CitiCreditUnionFactory : ICreditUnionFactory
    {
        public override ILoanAccount CreateLoanAccount()
        {
            CitiLoanAccount obj = new CitiLoanAccount();
            return obj;
        }

        public override ISavingsAccount CreateSavingsAccount()
        {
            CitiSavingsAccount obj = new CitiSavingsAccount();

            return obj;
        }
    }

    //ProductA2
    public class NationalSavingsAccount : ISavingsAccount
    {
        public NationalSavingsAccount()
        {
            Console.WriteLine("Returned National Savings Account");
        }
    }

    //ProductB2
    public class NationalLoanAccount : ILoanAccount
    {
        public NationalLoanAccount()
        {
            Console.WriteLine("Returned National Loan Account");
        }
    }

    public class NationalCreditUnionFactory : ICreditUnionFactory
    {
        public override ILoanAccount CreateLoanAccount()
        {
            NationalLoanAccount obj = new NationalLoanAccount();
            return obj;
        }

        public override ISavingsAccount CreateSavingsAccount()
        {
            NationalSavingsAccount obj = new NationalSavingsAccount();
            return obj;
        }
    }

    public class CitiCreditUnionFactoryProvider
    {
        public static ICreditUnionFactory GetCreditUnionFactory(string accountNo)
        {
            if (accountNo.Contains("CITI")) return new CitiCreditUnionFactory();
            else if (accountNo.Contains("NATIONAL")) return new NationalCreditUnionFactory();
            else
                return null;
        }
    }

}
