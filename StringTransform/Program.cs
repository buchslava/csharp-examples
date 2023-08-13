// Implement the transformer allows us to get "4a2b5c1d" by "aaabbcccccda"
using System.Text.Json;
class Transformer
{
    public static String transform(string inputString)
    {
        Dictionary<char, int> counters = new Dictionary<char, int>();
        foreach (char currentChar in inputString)
        {

            int currentValue;
            bool success = counters.TryGetValue(currentChar, out currentValue);

            if (success)
            {
                counters.Remove(currentChar);
                counters.Add(currentChar, currentValue + 1);
            }
            else
            {
                counters.Add(currentChar, 1);
            }
        }

        System.Console.WriteLine(JsonSerializer.Serialize(counters));

        string result = "";
        foreach (KeyValuePair<char, int> entry in counters)
        {
            result += entry.Value.ToString() + entry.Key;

        }

        return result;
    }
    static void Main(string[] args)
    {
        System.Console.WriteLine(transform("aaabbcccccda"));
        // System.Console.ReadKey();
    }
}
