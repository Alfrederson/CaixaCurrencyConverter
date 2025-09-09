namespace CurrencyConverterMsTest
{
    using CurrencyConverter;
    // TAREFA
    // Testar Conversão A -> B
    // Testar Conversão A -> B, B -> A (colocar na tabela A->B e B->A)


    [TestFixture]
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
        [Test]
        public void ConvertAtoB()
        {
            var result = _converter.Convert(new Money(1.0m, Currency.USD), Currency.BRL);
            Assert.That(result.Amount, Is.EqualTo(2.0m));
            Assert.That(result.Currency, Is.EqualTo(Currency.BRL));
            
        }

        [Test]
        public void ConvertAToBToA_ShouldYieldOriginalValue()
        {
            var brlPorUsd = _converter.Convert(new Money(1.0m, Currency.USD), Currency.BRL);
            var usdPorBrl = _converter.Convert(new Money(brlPorUsd.Amount, Currency.BRL), Currency.USD);

            Assert.That(usdPorBrl.Amount,Is.EqualTo(1.0m));
            Assert.That(usdPorBrl.Currency,Is.EqualTo(Currency.USD));
        }
        
    }
}
