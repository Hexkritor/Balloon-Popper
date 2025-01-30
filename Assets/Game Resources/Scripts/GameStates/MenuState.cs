using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hexkritor.BalloonPopper.GameStates
{
    public class MenuState : AbstractGameState
    {
        [SerializeField]
        private Button playButton;

        public override void Initialize(GameStateManager targetManager)
        {
            base.Initialize(targetManager);
            playButton.onClick.AddListener(PlayGame);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public void PlayGame()
        {
            gameStateManager?.ShowState(GameStateType.Game);
        }

        public void ShowLeaderboard()
        {
            gameStateManager?.ShowState(GameStateType.Leaderboard);
        }
    }
}
