namespace Task4_1
{
    internal class ElementChangedEventArgs<T> : EventArgs
    {
        public T OldValue { get; }
        public T NewValue { get; }
        public int Index { get; }

        public ElementChangedEventArgs(T oldValue, T newValue, int index)
        {
            OldValue = oldValue;
            NewValue = newValue;
            Index = index;
        }
    }
}
