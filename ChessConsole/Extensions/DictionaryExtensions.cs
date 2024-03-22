namespace ChessConsole.Extensions;

public static class DictionaryExtensions
{
    public static void ChangeKey<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey oldKey, TKey newKey)
    {
        if (!dict.Remove(oldKey, out var value)) return;

        dict.Add(newKey, value);
    }
}