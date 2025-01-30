using Hexkritor.BalloonPopper.Data;
using Hexkritor.BalloonPopper.Managers;
using Hexkritor.BalloonPopper.UI;
using UnityEngine;

namespace Hexkritor.BalloonPopper.GameStates
{
    public class GameState : AbstractGameState
    {

        [SerializeField]
        private LevelManager levelManager;
        [SerializeField]
        private Player player;
        [SerializeField]
        private SpawnerContainer spawnerContainer;
        [SerializeField]
        private GameUI gameUI;

        public override void Initialize(GameStateManager targetManager)
        {
            base.Initialize(targetManager);
            levelManager.Initialize(player, spawnerContainer);
            spawnerContainer.Initialize(levelManager);
            gameUI.OnScoreSubmit += () => gameStateManager.ShowState(GameStateType.Leaderboard);
            gameUI.Initialize(levelManager);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            levelManager.ResetObject();
            player.Initialize();
        }
    }
}
