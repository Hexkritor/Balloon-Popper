using Hexkritor.BalloonPopper.Managers;
using Hexkritor.Tools.Factories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Hexkritor.BalloonPopper.Data
{
    public class BalooonFreezeFactory : BalloonFactory
    {
        [SerializeField]
        private float freezeTime;

        protected override void InitializeBalloon(Balloon newBalloon)
        {
            newBalloon.Initialize();
            newBalloon.Health.OnDeath += () => levelManager.CheckKill(newBalloon);
            newBalloon.Health.OnDeath += () => levelManager.Spawners.DoAction(Freeze);
            newBalloon.Health.OnDeath += () => levelManager.DelaySpawn(freezeTime);
            newBalloon.Movement.OnMoveComplete += levelManager.Player.Life.LoseLife;
            newBalloon.Score.OnGainScore += levelManager.Player.Score.AddScore;
            ResetObject(newBalloon);
        }

        private void Freeze(Balloon target)
        {
            target.Movement.StopMove(freezeTime);
        }
    }
}
