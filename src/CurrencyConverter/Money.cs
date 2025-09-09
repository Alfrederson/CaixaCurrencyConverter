namespace CurrencyConverter
{
    public readonly struct Money
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        public Money(decimal amount, Currency currency)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);

            this.Amount = amount;
            this.Currency = currency;
        }
    }
}
