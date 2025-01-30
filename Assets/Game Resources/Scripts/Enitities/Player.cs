using Hexkritor.BalloonPopper.Data.Components;
using UnityEngine;

namespace Hexkritor.BalloonPopper.Data
{
    public class Player : MonoBehaviour
    {
        public LifeLogic Life;
        public PlayerScoreLogic Score;

        public void Initialize()
        {
            Life.Initialize();
            Score.Initialize();
        }
    }
}
