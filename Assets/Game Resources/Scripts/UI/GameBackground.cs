using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Hexkritor.BalloonPopper.UI
{
    public class GameBackground : MonoBehaviour
    {

        [SerializeField]
        private Image currentLevelBG;
        [SerializeField]
        private Image nextLevelBG;

        [SerializeField]
        private float progressFillDuration;

        public event Action OnAnimationEnded = delegate { };

        public void SetColors(Color currentLevelColor, Color nextLevelColor)
        {
            SetCurrentLevelBGColor(currentLevelColor);
            SetNextLevelBGColor(nextLevelColor);
        }

        public void SetCurrentLevelBGColor(Color color)
        {
            currentLevelBG.color = color;
        }

        public void SetNextLevelBGColor(Color color)
        {
            nextLevelBG.color = color;
        }

        public void ShowLevelProgress(float progress)
        {
            nextLevelBG.DOFillAmount(progress, progressFillDuration).OnComplete(() => OnAnimationEnded());
        }

        public void ShowLevelProgressInstant(float progress)
        {
            nextLevelBG.fillAmount = progress;
            OnAnimationEnded();
        }
    }
}
