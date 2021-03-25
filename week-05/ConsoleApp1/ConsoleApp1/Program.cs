﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IINGExchangeRate iNGExchangeRate2020 = new INGExchangeRate2020();
            IINGExchangeRate iNGExchangeRate2021 = new INGExchangeRate2021();

            IBTExchangeRate bTExchangeRate2020 = new BTExchangeRate2020();
            IBTExchangeRate bTExchangeRate2021 = new BTExchangeRate2021();

            Dictionary<Type, object> dependecyInjectionContainer = new Dictionary<Type, object>();
            dependecyInjectionContainer.Add(typeof(IINGExchangeRate), iNGExchangeRate2020);
            dependecyInjectionContainer.Add(typeof(IBTExchangeRate), bTExchangeRate2020);

            ConstructorInfo constructorInfo = typeof(ING).GetConstructors().FirstOrDefault();

            List<object> ingParams = new List<object>();

            foreach (ParameterInfo parameterInfo in constructorInfo.GetParameters())
            {
                Console.WriteLine(parameterInfo.ParameterType.ToString());

                ingParams.Add(dependecyInjectionContainer[parameterInfo.ParameterType]);
            }

            //ING ingInstance = Activator.CreateInstance(typeof(ING), ingParams) as ING;

            IBank ing = new ING(dependecyInjectionContainer[typeof(IINGExchangeRate)] as IINGExchangeRate, dependecyInjectionContainer[typeof(IBTExchangeRate)] as IBTExchangeRate);
            IBank bt = new BT(dependecyInjectionContainer[typeof(IBTExchangeRate)] as IBTExchangeRate);

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

    public class INGExchangeRate2020 : IINGExchangeRate
    {
        public decimal Value() => 4.8554M;
    }

    public class INGExchangeRate2021 : IINGExchangeRate
    {
        public decimal Value() => 4.86M;
    }

    public class BTExchangeRate2020 : IBTExchangeRate
    {
        public decimal Value() => 4.7554M;
    }

    public class BTExchangeRate2021 : IBTExchangeRate
    {
        public decimal Value() => 4.76M;
    }

    public class ING : IBank
    {
        private readonly IINGExchangeRate iNGExchangeRate;
        private readonly IBTExchangeRate bTExchangeRate;

        public ING(IINGExchangeRate iNGExchangeRate, IBTExchangeRate bTExchangeRate, IBTExchangeRate bTExchangeRate1, IBTExchangeRate bTExchangeRate2, IBTExchangeRate bTExchangeRate3, IBTExchangeRate bTExchangeRate4, IBTExchangeRate bTExchangeRate5, IBTExchangeRate bTExchangeRate6, IBTExchangeRate bTExchangeRate7)
        {
            this.iNGExchangeRate = iNGExchangeRate;
        }

        public decimal ExchangeInRON(decimal valueInEUR)
        {
            return valueInEUR * iNGExchangeRate.Value();
        }
    }

    public class BT : IBank
    {
        private readonly IBTExchangeRate bTExchangeRate;

        public BT(IBTExchangeRate bTExchangeRate)
        {
            this.bTExchangeRate = bTExchangeRate;
        }

        public decimal ExchangeInRON(decimal valueInEUR)
        {
            return valueInEUR * bTExchangeRate.Value();
        }
    }
}
