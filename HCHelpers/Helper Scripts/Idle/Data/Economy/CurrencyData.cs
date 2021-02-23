using Newtonsoft.Json;
using UnityEngine;

namespace Ali.Helper.Idle
{
    [System.Serializable]
    public class CurrencyData
    {
        public float initialAmount;
        public CurrencyType currencyType;

        [JsonConverter(typeof(HugeNumberSerializer))]
        [JsonProperty]
        protected HugeNumber amount;

        public CurrencyData()
        {

        }

        public virtual void Init()
        {
            amount = new HugeNumber(initialAmount);
        }

        public HugeNumber GetAmount()
        {
            return amount;
        }

        public virtual CurrencyData Clone()
        {
            var bc = CreateInstanceForClone();
            bc.initialAmount = initialAmount;
            bc.amount = amount;
            return bc;
        }

        protected virtual CurrencyData CreateInstanceForClone()
        {
            return new CurrencyData();
        }
    }
}