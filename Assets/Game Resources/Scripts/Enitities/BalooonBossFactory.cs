using Hexkritor.BalloonPopper.Managers;
using Hexkritor.Tools.Factories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Hexkritor.BalloonPopper.Data
{
    public class BalooonBossFactory : BalloonFactory
    {
        protected override void InitializeBalloon(Balloon newBalloon)
        {
            newBalloon.Initialize();
            newBalloon.Health.OnDeath += () => levelManager.CheckKill(newBalloon);
            newBalloon.Movement.OnMoveComplete += levelManager.Player.Life.LoseGame;
            newBalloon.Score.OnGainScore += levelManager.Player.Score.AddScore;
            ResetObject(newBalloon);
        }
    }
}
