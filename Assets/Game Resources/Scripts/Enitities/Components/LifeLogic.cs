using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hexkritor.BalloonPopper.Data.Components
{
    public class LifeLogic : MonoBehaviour
    {
        [SerializeField]
        private int startLives;

        private int lives;
        public int Lives => lives;

        public event Action<int> OnLivesChanged = delegate { };
        public event Action OnLivesDepleted = delegate { };

        public void Initialize()
        {
            lives = startLives;
            OnLivesChanged(lives);
        }

        public void LoseLife()
        {
            if (lives == 0)
            {
                return;
            }

            --lives;

            OnLivesChanged(lives);
            if (lives == 0)
            {
                OnLivesDepleted();
            }
        }

        public void LoseGame()
        {
            lives = 0;
            OnLivesChanged(lives);
            OnLivesDepleted();
        }
    }
}
