using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GAG.GameMetricsAndStats
{
    public class MetricsAndStatsUIManager : MonoBehaviour
    {
        [SerializeField] TMP_Text _timerIncTxt;
        [SerializeField] TMP_Text _timerDecTxt;
        [SerializeField] TMP_Text _healthTxt;
        [SerializeField] TMP_Text _scoreTxt;

        [SerializeField] Image _timerIncImg;
        [SerializeField] Image _timerDecImg;
        [SerializeField] Image _healthImg;

        private void OnEnable()
        {
            // Subscribe to events with methods for better readability
            MetricsAndStatsEvents.OnTimerIncChanged += UpdateTimerIncUI;
            MetricsAndStatsEvents.OnTimerDecChanged += UpdateTimerDecUI;
            MetricsAndStatsEvents.OnHealthChanged += UpdateHealthUI;
            MetricsAndStatsEvents.OnScored += UpdateScoreUI;
        }

        private void OnDisable()
        {
            // Unsubscribe from events to avoid potential memory leaks
            MetricsAndStatsEvents.OnTimerIncChanged -= UpdateTimerIncUI;
            MetricsAndStatsEvents.OnTimerDecChanged -= UpdateTimerDecUI;
            MetricsAndStatsEvents.OnHealthChanged -= UpdateHealthUI;
            MetricsAndStatsEvents.OnScored -= UpdateScoreUI;
        }

        private void UpdateTimerIncUI(float time, float fill)
        {
            _timerIncTxt.text = $"Timer: {(int)time}/20";
            _timerIncImg.fillAmount = fill;
        }

        private void UpdateTimerDecUI(float time, float fill)
        {
            _timerDecTxt.text = $"Timer: {(int)time}/20";
            _timerDecImg.fillAmount = fill;
        }

        private void UpdateHealthUI(int health, float fill)
        {
            _healthTxt.text = $"Health: {health}/100";
            _healthImg.fillAmount = fill;
        }

        private void UpdateScoreUI(int score)
        {
            _scoreTxt.text = $"Score: {score}";
        }
    }
}