using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.Idle
{
    [System.Serializable]
    public class RewardValueData : ValueData
    {
        public RewardType rewardType;
        public CurrencyType currencyType;

        public override void Init()
        {
            base.Init();
        }

        public override ValueData Clone()
        {
            var a = (RewardValueData)base.Clone();
            a.rewardType = rewardType;
            a.currencyType = currencyType;
            return a;
        }

        protected override ValueData CreateInstanceForClone()
        {
            return new RewardValueData();
        }
    }
}