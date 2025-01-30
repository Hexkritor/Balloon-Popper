using Hexkritor.BalloonPopper.Managers;
using System;
using TMPro;
using UnityEngine;

namespace Hexkritor.BalloonPopper.UI
{
    public class GameUI : MonoBehaviour
    {

        [SerializeField]
        private GameBackground gameBackground;
        [SerializeField]
        private GameOverScreen gameOverScreen;
        [SerializeField]
        private TMP_Text levelText;
        [SerializeField]
        private TMP_Text livesText;
        [SerializeField]
        private TMP_Text scoreText;

        private LevelManager levelManager;

        public event Action OnScoreSubmit = delegate { };

        public void Initialize(LevelManager levelManager)
        {
            this.levelManager = levelManager;

            levelManager.OnBalloonKill += gameBackground.ShowLevelProgress;
            levelManager.OnLevelStart += (_) => SetupBackgroundColors();
            levelManager.OnLevelStart += SetLevelText;
            levelManager.Player.Life.OnLivesChanged += SetLivesText;
            levelManager.Player.Score.OnScoreChanged += SetScoreText;
            levelManager.OnGameOver += ShowGameOverScreen;
            gameBackground.OnAnimationEnded += levelManager.CheckLevelProgress;
            gameOverScreen.OnScoreSubmit += OnScoreSubmit;
        }

        private void SetupBackgroundColors()
        {
            gameBackground.SetCurrentLevelBGColor(levelManager.CurrentLevel.LevelBackground);
            gameBackground.SetNextLevelBGColor(levelManager.NextLevel.LevelBackground);
            gameBackground.ShowLevelProgressInstant(0);
        }

        private void SetLevelText(int level)
        {
            levelText.text = $"LEVEL: {level}";
        }

        private void SetScoreText(int score)
        {
            scoreText.text = $"SCORE\n{score}";
        }

        private void SetLivesText(int lives)
        {
            livesText.text = $"LIVES: {lives}";
        }

        private void ShowGameOverScreen(int score)
        {
            gameOverScreen.ShowScreen(score);
        }
    }
}