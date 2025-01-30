using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Hexkritor.Tools.DOTween
{
    public abstract class AbstractTween : MonoBehaviour
    {
        [SerializeField]
        protected float duration;
        [SerializeField]
        protected Ease easeType;

        [SerializeField]
        protected bool isLooped;

        [SerializeField]
        protected bool autoPlayOnEnable;

        [SerializeField]
        protected UnityEvent onTweenCompleted;

        protected virtual void OnEnable()
        {
            if (autoPlayOnEnable == true)
            {
                DoTween();
            }
        }

        public abstract void DoTween();
    }
}
