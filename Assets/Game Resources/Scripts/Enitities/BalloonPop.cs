using Hexkritor.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Hexkritor.BalloonPopper.Data
{
    public class BalloonPop : MonoBehaviour, IPoolable<BalloonPop>
    {
        [SerializeField]
        private ParticleSystem particles;

        public ObjectPool<BalloonPop> Pool { get; set; }

        public void Get()
        {
            gameObject.SetActive(true);
            Invoke(nameof(Release), particles.main.duration);
        }

        public void Release()
        {
            Pool.Release(this);
            gameObject.SetActive(false);
        }
    }
}
