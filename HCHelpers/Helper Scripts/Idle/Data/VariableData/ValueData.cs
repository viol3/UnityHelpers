using Koopakiller.Numerics;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.Idle
{
    [System.Serializable]
    public class ValueData
    {
        public float initialValue;
        public float valueFactor;
        public FactorType valueFactorType;

        [JsonConverter(typeof(HugeNumberSerializer))]
        [JsonProperty]
        protected HugeNumber value;
        int level = 1;

        public virtual void Init()
        {
            value = new HugeNumber(initialValue);
        }

        public BigRational GetRationalValue()
        {
            return value.GetValue();
        }

        public HugeNumber GetValue()
        {
            return value;
        }

        public virtual void Upgrade()
        {
            Upgrade(valueFactor, valueFactorType);
        }

        public void Upgrade(float factor, FactorType factorType)
        {
            if (factorType == FactorType.Linear)
            {
                value.Add(factor);

            }
            else if (factorType == FactorType.Exponantial)
            {
                value.Multiply(factor);
            }
            level++;
        }

        public virtual ValueData Clone()
        {
            var bc = CreateInstanceForClone();
            bc.initialValue = initialValue;
            bc.valueFactor = valueFactor;
            bc.valueFactorType = valueFactorType;
            bc.value = value;
            return bc;
        }

        protected virtual ValueData CreateInstanceForClone()
        {
            return new ValueData();
        }

    }
}