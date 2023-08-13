
/*
{
  'Jack': 'Mary',
  'Ann': 'Mary',
  'John': 'Bob',
  'Lisa': 'Bob',
};

{ Mary: [ 'Jack', 'Ann' ], Bob: [ 'John', 'Lisa' ] }
*/
using System.Text.Json;
class Parents
{
  public static Dictionary<string, List<string>> transform(Dictionary<string, string> data)
  {
    Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
    foreach (KeyValuePair<string, string> entry in data)
    {
      List<string> currentValue;
      bool success = result.TryGetValue(entry.Value, out currentValue);
      if (success)
      {
        result.Remove(entry.Value);
      }
      else
      {
        currentValue = new List<string>();
      }

      currentValue.Add(entry.Key);
      result.Add(entry.Value, currentValue);
    }
    return result;

  }
  static void Main(string[] args)
  {
    Dictionary<string, string> inputData = new Dictionary<string, string>() {
          {"Jack", "Mary"},
          {"Ann", "Mary"},
          {"John", "Bob"},
          {"Lisa", "Bob"}
        };

    System.Console.WriteLine(JsonSerializer.Serialize(transform(inputData)));
    // System.Console.ReadKey();
  }
}
