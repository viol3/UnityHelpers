
using Ali.Helper.Idle;

public class HugeNumberHelper
{
    //static string[] tiers = { "K", "M", "B", "t", "q", "Q", "s", "S", "o", "n", "d", "U", "D", "T", "Qt", "Qd", "Sd", "St", "O", "N", "v", "c" };
    const string LETTERS = "ABCCDEFGHIJKLMNOPQRSTUVWXYZ";
    static string[] tiers = { "K", "M", "B", "T" };
    public static string GetSimplifiedHugeNumber(HugeNumber huge, uint decimalPlaces = 0)
    {
        int min = 4;
        string hugeString = "";
        if(decimalPlaces == 0)
        {
            hugeString = huge.ToString();
        }
        else
        {
            min = 7;
            hugeString = huge.ToFloatString(decimalPlaces);
        }
        
        
        if(hugeString.Length < min)
        {
            return hugeString;
        }
        else if(decimalPlaces > 0)
        {
            int endIndex = (int)(hugeString.Length - (decimalPlaces + 1));
            hugeString = hugeString.Substring(0, endIndex);
        }
        string tier = GetTierFromIndex(((hugeString.Length - 1) / 3) - 1);
        int dotIndex = ((hugeString.Length - 1) % 3) + 1;
        hugeString = hugeString.Substring(0, 3);
        if(dotIndex < 3)
        {
            hugeString = hugeString.Insert(dotIndex, ".");
        }
        return hugeString + tier;
    }

    static string GetTierFromIndex(int index)
    {
        if(index < tiers.Length)
        {
            return tiers[index];
        }
        int rawIndex = (index - tiers.Length);
        string result = "";
        result += LETTERS[rawIndex % LETTERS.Length];
        result += LETTERS[rawIndex % LETTERS.Length];
        for (int i = 0; i < rawIndex / LETTERS.Length; i++)
        {
            result += LETTERS[rawIndex % LETTERS.Length];
        }
        return result;
    }
}
