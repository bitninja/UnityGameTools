
namespace UnityGameTools
{
    public interface IVariable<T>
    {
        T GetValue();

        void SetValue(T value);
    }
}