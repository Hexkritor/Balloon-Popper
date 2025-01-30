using Hexkritor.BalloonPopper.Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Hexkritor.BalloonPopper.UI
{
    public class LeaderboardPanel : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text usernameText;
        [SerializeField]
        private TMP_Text scoreText;

        public void SetRecord(LeaderboardRecord record)
        {
            usernameText.text = record.Name;
            scoreText.text = $"{record.Score}";
        }
    }
}
