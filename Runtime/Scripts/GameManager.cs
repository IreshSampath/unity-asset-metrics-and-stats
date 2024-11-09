using Unity.Mathematics;
using UnityEngine;

namespace GAG.GameMetricsAndStats
{
    public class GameManager : MonoBehaviour
    {
        // Timer parameters
        float _currentTime = 0;
        const float _startTime = 0;
        [SerializeField] float _EndTime = 20;

        // Health parameters
        [SerializeField] int _currentHealth = 100;
        [SerializeField] int _maxHealth = 100;
        const int _minHealth = 0;

        // Score parameters
        int _currentScore = 0;
        const int _minScore = 0;

        // Update is called once per frame
        void Update()
        {
            _currentTime += Time.deltaTime;
            UpdateTimer();
        }

        void UpdateTimer()
        {
            if (_currentTime >= _EndTime)
            {
                _currentTime = _startTime;
            }

            float fillValueInc = math.remap(_startTime, _EndTime, 0, 1, _currentTime);
            Events.RaiseOnTimerIncChanged(_currentTime, fillValueInc);

            float fillValueDec = math.remap(_startTime, _EndTime, 1, 0, _currentTime);
            Events.RaiseOnTimerDecChanged(_EndTime - _currentTime, fillValueDec);
        }

        public void ResetTimer() // This is not working
        {
            _currentTime = _startTime;
            UpdateTimer();
        }

        public void SetHealth(int healthChange)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + healthChange, _minHealth, _maxHealth);

            float fillValue = math.remap(_maxHealth, _minHealth, 1, 0, _currentHealth);
            Events.RaiseOnHealthChanged(_currentHealth, fillValue);
        }

        public void SetScore(int scoreChange)
        {
            _currentScore = Mathf.Max(_currentScore + scoreChange, _minScore);
            Events.RaiseOnScored(_currentScore);
        }
    }
}
