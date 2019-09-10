using System;

namespace SilverFish.Helpers
{
    /// <summary>
    /// https://stackoverflow.com/a/839798/3782855
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class WriteOnce<T>
    {
        private bool _hasValue;

        public override string ToString()
        {
            return Value.ToString();
        }

        public T Value
        {
            get
            {
                if (!_hasValue)
                {
                    throw new InvalidOperationException("Value not set");
                }
                return _value;
            }
            set
            {
                if (_hasValue)
                {
                    throw new InvalidOperationException("Value already set");
                }
                _value = value;
                _hasValue = true;
            }
        }

        private T _value;

        public static implicit operator T(WriteOnce<T> value)
        {
            return value.Value;
        }
    }
}
