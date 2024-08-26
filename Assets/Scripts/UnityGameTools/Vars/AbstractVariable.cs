using UnityEngine;

namespace UnityGameTools
{
    public abstract class AbstractVariable<T> : MonoBehaviour, IVariable<T>
    {
        public T value;

        public T GetValue()
        {
            return this.value;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }
    }
}