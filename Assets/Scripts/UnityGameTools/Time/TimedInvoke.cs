using UnityEngine;
using UnityEngine.Events;

namespace UnityGameTools
{
    public class TimedInvoke : MonoBehaviour
    {
        public enum TimerType { Periodic, Once }

        public UnityEvent Notify;

        public TimerType type;

        public float duration;

        public bool runTimerOnAwake;

        void Awake()
        {
            if (!runTimerOnAwake)
            {
                return;
            }

            StartTimer();
        }

        public void StartTimer()
        {

            if (type == TimerType.Periodic)
            {
                InvokeRepeating("OnTime", duration, duration);
            }
            else
            {
                Invoke("OnTime", duration);
            }
        }

        public void StopTimer()
        {
            CancelInvoke("OnTime");
        }

        private void OnTime()
        {
            Notify?.Invoke();
        }
    }
}