using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hexkritor.BalloonPopper.Data.Components
{
    public class PlayerScoreLogic : MonoBehaviour
    {
        private int score = 0;

        public int Score => score;

        public event Action<int> OnScoreChanged = delegate { };

        public void Initialize()
        {
            score = 0;
            OnScoreChanged(score);
        }

        public void AddScore(int value)
        {
            score += value;
            OnScoreChanged(score);
        }
    }
}
