using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IBank ing = new ING();
            IBank bt = new BT();

            Console.WriteLine($"ING converts 100 EUR into {ing.ExchangeInRON(100)}");
            Console.WriteLine($"BT converts 100 EUR into {bt.ExchangeInRON(100)}");


            Console.ReadKey();
        }
    }

    // fiecare banca are propriul schimb valutar
    // ING: 1 EUR = 4.8554 RON
    // BT: 1 EUR = 4.7554 RON
    // GOAL: Create banks that exchange from EUR to RON currency

    public interface IBank // ING, BT
    {
        decimal ExchangeInRON(decimal valueInEUR);
    }

    public interface IINGExchangeRate
    {
        decimal Value();
    }

    public interface IBTExchangeRate
    {
        decimal Value();
    }

    public class INGExchangeRate : IINGExchangeRate
    {
        public decimal Value() => 4.8554M;
    }

    public class BTExchangeRate : IBTExchangeRate
    {
        public decimal Value() => 4.7554M;
    }

    public class ING : IBank
    {
        private readonly IINGExchangeRate iNGExchangeRate;        

        public decimal ExchangeInRON(decimal valueInEUR)
        {
            decimal EURtoRONExchangeRate = 4.8554M;

            return valueInEUR * iNGExchangeRate.Value();
        }
    }

    public class BT : IBank
    {
        private readonly IBTExchangeRate bTExchangeRate;

        public decimal ExchangeInRON(decimal valueInEUR)
        {
            decimal EURtoRONExchangeRate = 4.7554M;

            return valueInEUR * bTExchangeRate.Value();
        }
    }
}
