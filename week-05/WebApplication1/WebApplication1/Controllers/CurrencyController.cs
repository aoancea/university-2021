using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IBank bank;

        public CurrencyController(IBank bank)
        {
            this.bank = bank;
        }

        [HttpGet]
        public decimal ExchangeInRON(decimal valueInEUR)
        {
            return bank.ExchangeInRON(valueInEUR);
        }
    }

    public interface IBank // ING, BT
    {
        decimal ExchangeInRON(decimal valueInEUR);
    }

    public interface IINGExchangeRate
    {
        decimal Value();
    }

    public class INGExchangeRate2020 : IINGExchangeRate
    {
        public decimal Value() => 4.8554M;
    }

    public class INGBank : IBank
    {
        private readonly IINGExchangeRate iNGExchangeRate;

        public INGBank(IINGExchangeRate iNGExchangeRate)
        {
            this.iNGExchangeRate = iNGExchangeRate;
        }

        public decimal ExchangeInRON(decimal valueInEUR)
        {
            return valueInEUR * iNGExchangeRate.Value();
        }
    }
}
