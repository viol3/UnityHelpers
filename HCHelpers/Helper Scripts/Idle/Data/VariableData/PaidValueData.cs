using Newtonsoft.Json;
using UnityEngine;

namespace Ali.Helper.Idle
{
    [System.Serializable]
    public class PaidValueData : ValueData
    {
        [Space]
        public float initialUpgradeCost;
        public float upgradeCostFactor;
        public FactorType upgradeCostFactorType;

        [JsonConverter(typeof(HugeNumberSerializer))]
        [JsonProperty]
        protected HugeNumber upgradeCost;

        public override void Init()
        {
            upgradeCost = new HugeNumber(initialUpgradeCost);
            base.Init();
        }

        public HugeNumber GetUpgradeCost()
        {
            return upgradeCost;
        }

        public override void Upgrade()
        {
            base.Upgrade();
            UpgradeCost(upgradeCostFactor, upgradeCostFactorType);
        }

        public void UpgradeCost(float value, FactorType factorType)
        {
            if (factorType == FactorType.Linear)
            {
                upgradeCost.Add(value);
            }
            else if (factorType == FactorType.Exponantial)
            {
                upgradeCost.Multiply(value);
            }
        }

        public override ValueData Clone()
        {
            var a = (PaidValueData)base.Clone();
            a.initialUpgradeCost = initialUpgradeCost;
            a.upgradeCostFactor = upgradeCostFactor;
            a.upgradeCostFactorType = upgradeCostFactorType;
            a.upgradeCost = upgradeCost;
            return a;
        }

        protected override ValueData CreateInstanceForClone()
        {
            return new PaidValueData();
        }
    }
}