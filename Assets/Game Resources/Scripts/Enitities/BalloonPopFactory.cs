using Hexkritor.Tools.Factories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexkritor.BalloonPopper.Data
{
    public class BalloonPopFactory : AbstractFactory<BalloonPop>
    {
        [SerializeField]
        private BalloonPop particles;

        public override BalloonPop Create()
        {
            return Instantiate(particles);
        }

        public override BalloonPop Create(Transform parent)
        {
            return Instantiate(particles, transform);
        }

        public override void ResetObject(BalloonPop target)
        {
        }
    }
}
