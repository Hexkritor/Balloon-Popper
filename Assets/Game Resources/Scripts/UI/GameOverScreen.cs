using Hexkritor.BalloonPopper.Data;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hexkritor.BalloonPopper.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text scoreText;
        [SerializeField]
        private TMP_InputField nameText;
        [SerializeField]
        private Button applyButton;

        private int score;

        public event Action OnScoreSubmit = delegate { };

        public void Awake()
        {
            nameText.onValueChanged.AddListener(ActivateButton);
        }

        public void ShowScreen(int score)
        {
            this.score = score;
            gameObject.SetActive(true);
            scoreText.text = $"SCORE: {score}";
            nameText.text = $"";
            ActivateButton("");
        }

        public void ActivateButton(string text)
        {
            applyButton.interactable = text.Length > 0;
        }

        public void SubmitScore()
        {
            LeaderboardDatabase.AddScore(nameText.text, score);
            OnScoreSubmit();
            gameObject.SetActive(false);
        }
    }
}