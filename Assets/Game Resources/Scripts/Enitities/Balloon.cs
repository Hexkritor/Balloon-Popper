using Hexkritor.BalloonPopper.Data;
using Hexkritor.BalloonPopper.Data.Components;
using Hexkritor.Tools.Factories;
using Hexkritor.Tools.Interfaces;
using UnityEngine;
using UnityEngine.Pool;

namespace Hexkritor.BalloonPopper.Data
{
    public class Balloon :MonoBehaviour, IPoolable<Balloon>
    {
        public HealthLogic Health;
        public HealthVisual HealthVisual;
        public MovementLogic Movement;
        public BalloonScoreLogic Score;

        public ObjectPool<Balloon> Pool { get; set; }
        public BalloonType Type { get; set; }

        public virtual void Initialize()
        {
            Health.OnHealthChange += HealthChangeHandler;
            Health.OnTakeDamage += TakeDamageHandler;
            Health.OnDeath += Kill;
            ResetObject();
        }

        public void ResetObject()
        {
            Health.Initialize();
            Movement.Initialize();
        }

        public void OnMouseUpAsButton()
        {
            Health.TakeDamage(1);
        }

        public void Get()
        {
            ResetObject();
            gameObject.SetActive(true);
        }

        public void Release()
        {
            gameObject.SetActive(false);
            Pool.Release(this);
        }

        protected virtual void Kill()
        {
            Score.AddKillScore();
            Movement.StopMove();
            Release();
        }

        protected void HealthChangeHandler(int health)
        {
            HealthVisual.SetText(health);
        }

        protected void TakeDamageHandler(int damage)
        {
            Score.AddTapScore();
        }
    }
}
