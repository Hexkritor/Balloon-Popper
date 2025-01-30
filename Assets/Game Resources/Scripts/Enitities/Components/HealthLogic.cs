using System;
using UnityEngine;
using UnityEngine.Events;

namespace Hexkritor.BalloonPopper.Data.Components
{
    public class HealthLogic : MonoBehaviour
    {

        [SerializeField]
        private int baseHealth;
        [SerializeField]
        private UnityEvent OnDeathAction;

        private int health;

        public int Health => health;
        public bool IsDead { get; private set; }

        public event Action<int> OnHealthChange = delegate { };
        public event Action<int> OnTakeDamage = delegate { };
        public event Action OnDeath = delegate { };

        public void Initialize()
        {
            health = baseHealth;
            OnHealthChange(health);
            IsDead = false;
        }

        public void TakeDamage(int value)
        {
            health = Mathf.Clamp(health - value, 0, int.MaxValue);
            OnHealthChange(health);
            OnTakeDamage(value);
            if (health == 0 && IsDead == false)
            {
                OnDeath();
                OnDeathAction.Invoke();
                IsDead = true;
            }
        }

        public void SetHealth(int value)
        {
            health = Mathf.Clamp(value, 0, int.MaxValue);
            OnHealthChange(health);
            if (health == 0 && IsDead == false)
            {
                OnDeath();
                OnDeathAction.Invoke();
                IsDead = true;
            }
        }
    }
}