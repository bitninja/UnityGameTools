namespace UnityGameTools
{
    public class IntVar : AbstractVariable<int>
    {
        public void Increment()
        {
            SetValue(value + 1);
        }

        public void Decrement()
        {
            SetValue(value - 1);
        }
    }
}