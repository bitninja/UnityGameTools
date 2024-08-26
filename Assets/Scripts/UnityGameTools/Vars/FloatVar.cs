namespace UnityGameTools
{
    public class FloatVar : AbstractVariable<float>
    {
        public void Increment()
        {
            SetValue(value + 1f);
        }

        public void Decrement()
        {
            SetValue(value - 1f);
        }
    }
}