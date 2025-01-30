using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Hexkritor.BalloonPopper.Data
{
    class ParticlesSpawner : MonoBehaviour
    {
        [SerializeField]
        private BalloonPopFactory factory;
        [SerializeField]
        private int startAmount;
        [SerializeField]
        private int maxSize;

        private Transform cachedTransform;

        private ObjectPool<BalloonPop> pool;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            cachedTransform = transform;
            pool = new ObjectPool<BalloonPop>
            (
                createFunc: () => factory.Create(cachedTransform),
                actionOnGet: (x) => { x.Get(); factory.ResetObject(x); },
                defaultCapacity: startAmount,
                maxSize: maxSize
            );
        }

        public void Spawn(Vector3 position)
        {
            var pop = pool.Get();
            pop.Pool = pool;
            pop.transform.position = position;
        }
    }
}
