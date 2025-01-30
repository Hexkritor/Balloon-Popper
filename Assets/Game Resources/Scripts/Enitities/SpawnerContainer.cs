using Hexkritor.BalloonPopper.Data;
using Hexkritor.BalloonPopper.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Hexkritor.BalloonPopper.Data
{
    public class SpawnerContainer: MonoBehaviour
    {
        [SerializeField]
        private List<SpawnerData> spawners = new();

        public void Initialize(LevelManager levelManager)
        {
            foreach (var spawner in spawners)
            {
                spawner.Spawner?.Initialize(levelManager);
            }
        }

        public Balloon Spawn(BalloonType balloonType)
        {
            var spawner = spawners.Find(x => x.BalloonType == balloonType);
            var balloon = spawner?.Spawner?.Spawn();
            balloon.Type = spawner != null ? spawner.BalloonType : BalloonType.None ;
            return balloon;
        }

        public void ReleaseAll()
        {
            foreach (var spawner in spawners)
            {
                spawner.Spawner?.ReleaseAll();
            }
        }

        public void DoAction(Action<Balloon> performedAction)
        {
            foreach (var spawner in spawners)
            {
                for (int i = spawner.Spawner.ActiveBalloons.Count - 1; i >= 0; --i)
                {
                    performedAction(spawner.Spawner.ActiveBalloons[i]);
                }
            }
        }
    }

    [Serializable]
    public class SpawnerData
    {
        public BalloonType BalloonType;
        public BalloonSpawner Spawner;
    }
}
