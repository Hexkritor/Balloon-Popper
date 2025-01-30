using Hexkritor.BalloonPopper.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hexkritor.BalloonPopper.UI
{
    public class LeaderboardUI : MonoBehaviour
    {
        [SerializeField]
        private LeaderboardPanel panelPrefab;
        [SerializeField]
        private RectTransform leaderboardContent;

        private List<LeaderboardPanel> panels = new();

        public void ShowScores()
        {
            var records = LeaderboardDatabase.Data.Records;

            for (int i = 0; i < records.Count; ++i)
            {
                if (panels.Count <= i)
                {
                    panels.Add(Instantiate(panelPrefab, leaderboardContent));
                }
                panels[i].SetRecord(records[i]);
            }
        }
    }
}
