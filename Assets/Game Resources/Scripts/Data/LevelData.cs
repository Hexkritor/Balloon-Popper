using System.Collections.Generic;
using UnityEngine;

namespace Hexkritor.BalloonPopper.Data
{
    [CreateAssetMenu(fileName = "New Level Data", menuName = "Game/Level Data")]
    public class LevelData : ScriptableObject
    {
        public bool IsBossLevel;
        public Color LevelBackground;
        public int KillsRequired;
        public float SpawnTime;
        public List<LevelBalloonSpawnData> SpawnedBalloons;

        public BalloonType GetRandomBalloon()
        {
            float randomValue = Random.value;
            foreach (var spawnedBallon in SpawnedBalloons)
            {
                if (randomValue > spawnedBallon.SpawnProbability)
                {
                    randomValue -= spawnedBallon.SpawnProbability;
                    continue;
                }
                return spawnedBallon.BalloonType;
            }
            return BalloonType.None;
        }
    }

    [System.Serializable]
    public class LevelBalloonSpawnData
    {
        public BalloonType BalloonType;
        [Range(0, 1)]
        public float SpawnProbability;
    }
}
