using System.Collections.Generic;
using UnityEngine;

namespace Hexkritor.BalloonPopper.Data
{
    [CreateAssetMenu(fileName = "New Level Settings", menuName = "Game/Level Settings")]
    public class LevelSettings : ScriptableObject
    {
        [Min(0)]
        public float SpeedMultiplierPerLevel = 1;
        [Min(0)]
        public float BonusBalloonSpawnDelay = 60;

        public List<BalloonType> BonusBalloonTypes;

        public List<LevelData> levels;

        public LevelData GetLevel(int level)
        {
            if (level < 1 || level > levels.Count)
            {
                return null;
            }

            return levels[level - 1];
        }

        public LevelData GetLoopedLevel(int level)
        {
            if (level < 0)
            {
                return null;
            }

            return levels[(level - 1) % levels.Count];
        }
    }
}