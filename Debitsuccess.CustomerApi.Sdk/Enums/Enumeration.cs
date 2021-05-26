using System;
using System.Collections.Generic;
using System.Reflection;

namespace Debitsuccess.CustomerApi.Sdk.Enums
{
    public abstract class Enumeration : IComparable
    {
        private string _value;
        private readonly string _name;

        protected Enumeration()
        {
        }

        protected Enumeration(string name)
        {
            _name = name;
        }

        protected Enumeration(string name, string value)
        {
            _value = value;
            _name = name;
        }

        public void SetValue(string value)
        {
            this._value = value;
        }

        public string Value
        {
            get { return _value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return Name;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = _value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public int CompareTo(object other)
        {
            return Value.CompareTo(((Enumeration)other).Value);
        }
    }
}
