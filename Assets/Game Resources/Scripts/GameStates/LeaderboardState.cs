using Hexkritor.BalloonPopper.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexkritor.BalloonPopper.GameStates
{
    public class LeaderboardState : AbstractGameState
    {
        [SerializeField]
        private LeaderboardUI leaderboardUI;

        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            leaderboardUI.ShowScores();
        }

        public void GoToMenu()
        {
            gameStateManager.ShowState(GameStateType.Menu);
        }
    }
}