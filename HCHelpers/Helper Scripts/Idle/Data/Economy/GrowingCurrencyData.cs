namespace Ali.Helper.Idle
{
    [System.Serializable]
    public class GrowingCurrencyData : CurrencyData
    {
        public PaidValueData productionIncome;

        public override void Init()
        {
            base.Init();
            productionIncome.Init();
            amount = new HugeNumber(initialAmount);
        }

        public void Product(float seconds)
        {
            amount.Add(seconds * productionIncome.GetRationalValue());
        }

        public HugeNumber GetProductableAmount(float seconds)
        {
            HugeNumber result = productionIncome.GetValue();
            result.Multiply(seconds);
            return result;
        }

        public void Gain(HugeNumber other)
        {
            amount.Add(other.GetValue());
        }

        public void Spend(HugeNumber other)
        {
            amount.Subtract(other.GetValue());
        }

        public void Set(HugeNumber other)
        {
            amount = other;
        }

        public bool CanBeUpgrade()
        {
            return amount.IsGreaterThanOrEqueal(productionIncome.GetUpgradeCost());
        }

        public void Upgrade()
        {
            productionIncome.Upgrade();
        }

        public override CurrencyData Clone()
        {
            var a = (GrowingCurrencyData)base.Clone();
            a.productionIncome = (PaidValueData)productionIncome.Clone();
            return a;
        }

        protected override CurrencyData CreateInstanceForClone()
        {
            return new GrowingCurrencyData();
        }
    }
}