using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var policy = new Policy();

            var insuredName = Policy.Instance.GetInsuredName();
            Console.WriteLine(insuredName);
        }
    }

    public class Policy
    {
        private static readonly Policy _instance = new Policy();
        public static Policy Instance
        {
            get
            {
                lock (_instance)
                {
                    return _instance;
                }
            }
        }

        public Policy()
        {

        }

        private int Id { get; set; } = 123;
        private string Insured { get; set; } = "Nhuan Luong";
        public string GetInsuredName() => Insured;

    }
}
