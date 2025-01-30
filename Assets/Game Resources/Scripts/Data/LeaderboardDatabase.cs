using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexkritor.BalloonPopper.Data
{
    public static class LeaderboardDatabase
    {
        private const string leaderboardFieldName = "Leaderboards";

        private static LeaderboardData data;

        public static LeaderboardData Data
        {
            get
            {
                if (data == null)
                {
                    LoadData();
                }
                return data;
            }
        }

        public static void AddScore(string name, int score)
        {
            Data.Records.Add(new LeaderboardRecord() { Name = name, Score = score });
            SortData();
            Save();
        }

        public static void SortData()
        {
            Data.Records.Sort((x, y) => -x.Score.CompareTo(y.Score));
        }

        public static void Save()
        {
            PlayerPrefs.SetString(leaderboardFieldName, JsonUtility.ToJson(data));
            PlayerPrefs.Save();
        }

        private static void LoadData()
        {
            data = JsonUtility.FromJson<LeaderboardData>
            (
                PlayerPrefs.GetString(leaderboardFieldName, JsonUtility.ToJson(new LeaderboardData()))
            );
        }
    }

    [Serializable]
    public class LeaderboardData
    {
        public List<LeaderboardRecord> Records = new(); 
    }

    [Serializable]
    public class LeaderboardRecord
    {
        public string Name;
        public int Score;
    }
}
