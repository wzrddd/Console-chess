namespace ChessConsole.Extensions;

public static class DictionaryExtensions
{
    public static bool ChangeKey<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey oldKey, TKey newKey)
    {
        if (!dict.Remove(oldKey, out var value))
            return false;

        dict.Add(newKey, value);
        return true;
    }
}