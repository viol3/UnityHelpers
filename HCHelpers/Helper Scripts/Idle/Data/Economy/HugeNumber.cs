using Koopakiller.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.Idle
{
    [System.Serializable]
    public struct HugeNumber
    {
        BigRational value;

        public HugeNumber(BigRational bigRational)
        {
            value = bigRational;
        }

        public HugeNumber(string bigRationalText)
        {
            value = BigRational.Parse(bigRationalText, "0123456789", 10, System.Globalization.CultureInfo.CurrentCulture);
        }

        public HugeNumber(float bigRational)
        {
            value = bigRational;
        }

        public HugeNumber(int bigRational)
        {
            value = bigRational;
        }

        public void Set(HugeNumber huge)
        {
            value = huge.GetValue();
        }

        public void Set(float number)
        {
            value = number;
        }

        public BigRational GetValue()
        {
            return value;
        }

        public void Add(int addition)
        {
            Add((float)addition);
        }

        public void Add(BigRational other)
        {
            value = BigRational.Add(value, other);
        }

        public void Add(HugeNumber other)
        {
            Add(other.GetValue());
        }

        public void Subtract(float subtraction)
        {
            value -= subtraction;
        }

        public void Subtract(int subtraction)
        {
            Subtract((float)subtraction);
        }

        public void Subtract(BigRational other)
        {
            value = BigRational.Subtract(value, other);
        }

        public void Subtract(HugeNumber other)
        {
            Subtract(other.GetValue());
        }

        public void Multiply(float multiplication)
        {
            value *= multiplication;
        }

        public void Multiply(int multiplication)
        {
            Multiply((float)multiplication);
        }

        public void Multiply(BigRational other)
        {
            value = BigRational.Multiply(value, other);
        }

        public void Divide(float division)
        {
            value /= division;
        }

        public void Divide(int division)
        {
            Divide((float)division);
        }

        public void Divide(BigRational other)
        {
            value = BigRational.Divide(value, other);
        }

        public float MultiplicativeInverse(float divider = 1f)
        {
            if (value > 100000f)
            {
                return 0.00001f;
            }
            if (value < 0.000001f)
            {
                return divider / 0.000001f;
            }
            return divider / (float)value;
        }

        public bool IsEqual(HugeNumber huge)
        {
            return value.IsEqual(huge.GetValue());
        }

        public bool IsGreaterThan(HugeNumber huge)
        {
            return value.IsGreater(huge.GetValue());
        }

        public bool IsGreaterThanOrEqueal(HugeNumber huge)
        {
            return value.IsGreaterEqual(huge.GetValue());
        }

        public bool IsGreaterThan(float number)
        {
            return value.IsGreater(number);
        }

        public bool IsGreaterThanOrEqueal(float number)
        {
            return value.IsGreaterEqual(number);
        }

        public bool IsNegative()
        {
            return value.IsNegative;
        }

        public bool IsZero()
        {
            return value.IsZero;
        }



        public string ToSimplifiedString(uint decimalPlaces = 0)
        {
            return HugeNumberHelper.GetSimplifiedHugeNumber(this, decimalPlaces);
        }

        public override string ToString()
        {
            return value.ToDecimalString(0);
        }

        public string ToFloatString(uint decimalPlaces)
        {
            return value.ToDecimalString(decimalPlaces);
        }

        public static HugeNumber Add(HugeNumber huge, float addition)
        {
            return new HugeNumber(huge.GetValue() + addition);
        }

        public static HugeNumber Add(HugeNumber huge, int addition)
        {
            return new HugeNumber(huge.GetValue() + addition);
        }

        public static HugeNumber Add(HugeNumber huge1, HugeNumber huge2)
        {
            return new HugeNumber(huge1.GetValue() + huge2.GetValue());
        }

        public static HugeNumber Parse(string text)
        {
            return new HugeNumber(BigRational.Parse(text, "0123456789", 10, System.Globalization.CultureInfo.CurrentCulture));
        }
    }
}