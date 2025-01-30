using Hexkritor.BalloonPopper.Managers;
using Hexkritor.Tools.Factories;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Hexkritor.BalloonPopper.Data
{
    public class BalloonFactory : AbstractFactory<Balloon>
    {
        [SerializeField]
        protected Balloon balloon;

        [SerializeField]
        protected List<SplineContainer> splinesForMovement;

        protected LevelManager levelManager;


        public void Initialize(LevelManager levelManager)
        {
            this.levelManager = levelManager;
        }

        public override Balloon Create()
        {
            var newBalloon = Instantiate(balloon);
            InitializeBalloon(newBalloon);
            return newBalloon;
        }

        public override Balloon Create(Transform parent)
        {
            var newBalloon = Instantiate(balloon, parent);
            InitializeBalloon(newBalloon);
            return newBalloon;
        }

        public override void ResetObject(Balloon target)
        {
            target.Movement.SetMulitplier(levelManager.SpeedMultiplier);
            target.Movement.StartMove(splinesForMovement[Random.Range(0, splinesForMovement.Count)]);
        }

        protected virtual void InitializeBalloon(Balloon newBalloon)
        {
            newBalloon.Initialize();
            newBalloon.Health.OnDeath += () => levelManager.CheckKill(newBalloon);
            newBalloon.Movement.OnMoveComplete += levelManager.Player.Life.LoseLife;
            newBalloon.Score.OnGainScore += levelManager.Player.Score.AddScore;
            ResetObject(newBalloon);
        }

    }
}
