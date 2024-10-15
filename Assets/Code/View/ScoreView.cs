using Code.Model;
using TMPro;
using UnityEngine;

namespace Code.View
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private PlayerScore _playerScore;

        private void Start()
        {
            SetScore(_playerScore._score);
            _playerScore.OnScoreChanged += SetScore;
        }

        private void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}