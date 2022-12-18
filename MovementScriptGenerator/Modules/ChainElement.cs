
using System;

namespace MovementScriptGenerator.Modules
{
    public abstract class ChainElement
    {
        public ChainElement(string name)
        {
            Name = name;
            IconIndex = (int)Enum.Parse(typeof(ChainElementsEnum), GetType().Name);
        }
        public string Name { get; set; }

        public int IconIndex { get; }

        public T Clone<T>()
        {
            var inst = GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            return (T)inst?.Invoke(this, null);
        }
    }
}
