using System;

namespace _1_Scripts
{
    public static class TimerEvents
    {
        public static event Action TimerEnds;
        public static event Action TimerStart;
        
        public static void OnTimerEnds() => TimerEnds?.Invoke();
        public static void OnTimerStart() => TimerStart?.Invoke();
    }
}