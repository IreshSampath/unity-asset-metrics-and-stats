using System;
using UnityEngine;

namespace GAG.GameMetricsAndStats
{
    public class Events
    {
        public static event Action<float, float> OnTimerIncChanged;
        public static event Action<float, float> OnTimerDecChanged;
        public static event Action<int, float> OnHealthChanged;
        public static event Action<int> OnScored;

        // helper methods to raise events safely
        public static void RaiseOnTimerIncChanged(float time, float fill)
        {
            OnTimerIncChanged?.Invoke(time, fill);
        }

        public static void RaiseOnTimerDecChanged(float time, float fill)
        {
            OnTimerDecChanged?.Invoke(time, fill);
        }

        public static void RaiseOnHealthChanged(int health, float fill)
        {
            OnHealthChanged?.Invoke(health, fill);
        }

        public static void RaiseOnScored(int score)
        {
            OnScored?.Invoke(score);
        }
    }
}
