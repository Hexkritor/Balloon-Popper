
using Hexkritor.BalloonPopper.Data;
using Hexkritor.BalloonPopper.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Hexkritor.BalloonPopper.Data
{
    public class BalloonSpawner: MonoBehaviour
    {
        [SerializeField]
        private ParticlesSpawner particlesSpawner;
        [SerializeField]
        private BalloonFactory factory;
        [SerializeField]
        private int startAmount;
        [SerializeField]
        private int maxSize;

        private Transform cachedTransform;

        private ObjectPool<Balloon> pool;

        public List<Balloon> ActiveBalloons { get; private set; } = new();

        public void Initialize(LevelManager levelManager)
        {
            factory.Initialize(levelManager);
            cachedTransform = transform;
            pool = new ObjectPool<Balloon>
            (
                createFunc: () => factory.Create(cachedTransform),
                actionOnGet: (x) => { x.Get(); factory.ResetObject(x); },
                actionOnRelease: (x) => { particlesSpawner.Spawn(x.transform.position); ActiveBalloons.Remove(x); },
                defaultCapacity: startAmount,
                maxSize: maxSize
            );
        }

        public Balloon Spawn()
        {
            var balloon = pool.Get();
            balloon.Pool = pool;
            ActiveBalloons.Add(balloon);
            return balloon;
        }

        public void ReleaseAll()
        {
            for (int i = ActiveBalloons.Count - 1; i >= 0; --i)
            { 
                ActiveBalloons[i].Release();
            }
        }
    }
}
