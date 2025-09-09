
namespace CurrencyConverterMsTest
{
    using CurrencyConverter;

    // TAREFA
    // Testar Conversão A -> B
    // Testar Conversão A -> B, B -> A (colocar na tabela A->B e B->A)


    public class CurrencyConverterTests
    {
        private readonly CurrencyConverter _converter;
        private readonly RateProvider _provider;

        public CurrencyConverterTests()
        {
            _provider = new RateProvider(new Dictionary<(Currency, Currency), decimal>
            {
                {(Currency.USD, Currency.BRL), 2.0m },
                {(Currency.BRL, Currency.USD), 0.5m}
            });
            _converter = new CurrencyConverter(_provider);
        }

        [Fact]
        public void ShouldConvertAToB()
        {
            var result = _converter.Convert(new Money(1.0m, Currency.USD), Currency.BRL);
            Assert.Equal(2.0m, result.Amount);
        }
        [Fact]
        public void ConvertingAToBToA_ShouldYieldOriginalValue()
        {
            var brl_por_usd = _converter.Convert(new Money(1.0m, Currency.USD), Currency.BRL);
            var usd_por_brl = _converter.Convert(new Money(brl_por_usd.Amount, Currency.BRL), Currency.USD);
            Assert.Equal(1.0m, usd_por_brl.Amount);
            Assert.Equal(Currency.USD, usd_por_brl.Currency);
        }

    }
}
