using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Atesh.Collections.Specialized;

// This solution is from https://stackoverflow.com/a/66193734/2595856
class ReadOnlyDictionaryWrapper<TKey, TValue, TReadOnlyValue> : IReadOnlyDictionary<TKey, TReadOnlyValue> where TValue : TReadOnlyValue where TKey : notnull
{
    public IEnumerable<TKey> Keys => Dictionary.Keys;
    public IEnumerable<TReadOnlyValue> Values => Dictionary.Values.Cast<TReadOnlyValue>();
    public int Count => Dictionary.Count;
    public TReadOnlyValue this[TKey Key] => Dictionary[Key];

    readonly IDictionary<TKey, TValue> Dictionary;

    public ReadOnlyDictionaryWrapper(IDictionary<TKey, TValue> Dictionary) => this.Dictionary = Dictionary ?? throw new ArgumentNullException(nameof(Dictionary));

    public bool ContainsKey(TKey Key) => Dictionary.ContainsKey(Key);

    public bool TryGetValue(TKey Key, [MaybeNullWhen(false)] out TReadOnlyValue Value)
    {
        var Result = Dictionary.TryGetValue(Key, out var Value_);
        Value = Value_;

        return Result;
    }

    public IEnumerator<KeyValuePair<TKey, TReadOnlyValue>> GetEnumerator() => Dictionary.Select(X => new KeyValuePair<TKey, TReadOnlyValue>(X.Key, X.Value)).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public static class DictionaryExtensions
{
    public static IReadOnlyDictionary<TKey, TReadOnlyValue> AsReadOnly<TKey, TValue, TReadOnlyValue>(this IDictionary<TKey, TValue> This) where TValue : TReadOnlyValue where TKey : notnull => new ReadOnlyDictionaryWrapper<TKey, TValue, TReadOnlyValue>(This);
}