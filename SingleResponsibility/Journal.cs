using System;
using System.Collections.Generic;

namespace SingleResponsibility
{
    /// <summary>
    /// Journal is a class that contains operations only related to Journal
    /// If we want to persist other operation with Journal instance, we create separate class to work with.
    /// </summary>
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
}
