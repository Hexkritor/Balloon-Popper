using UnityEngine;

namespace Hexkritor.BalloonPopper.GameStates
{
    public abstract class AbstractGameState: MonoBehaviour
    {
        [SerializeField]
        protected GameStateType stateType;

        protected GameStateManager gameStateManager;

        public GameStateType StateType => stateType;

        public virtual void Initialize(GameStateManager targetManager)
        {
            gameStateManager = targetManager;
        }

        public abstract void Show();

        public abstract void Hide();
    }
}
