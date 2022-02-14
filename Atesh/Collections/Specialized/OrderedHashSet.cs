using System.Collections.ObjectModel;

namespace Atesh.Collections.Specialized
{
    // This class is based on this StackOverflow answer: https://stackoverflow.com/a/22053697/2595856
    public class OrderedHashSet<T> : KeyedCollection<T, T>
    {
        protected override T GetKeyForItem(T Item) => Item;
    }
}