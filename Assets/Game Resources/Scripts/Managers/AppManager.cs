using Hexkritor.BalloonPopper.GameStates;
using UnityEngine;

namespace Hexkritor.BalloonPopper.Managers
{
    public class AppManager : MonoBehaviour
    {
        [SerializeField]
        private GameStateManager gameStateManager;

        public void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (gameStateManager == null)
            {
                throw new System.NullReferenceException($"{nameof(GameStateManager)} isn't found. Can't run app");
            }
            gameStateManager?.Initialize();
        }
    }
}
