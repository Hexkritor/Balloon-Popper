using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Hexkritor.Tools.DOTween
{
    public class TweenTransformScale : AbstractTween
    {
        [SerializeField]
        private Vector3 startScale;
        [SerializeField]
        private Vector3 endScale;

        public override void DoTween()
        {
            transform.DOScale(endScale, duration).
                SetEase(easeType).
                From(startScale).
                OnComplete(onTweenCompleted.Invoke).
                SetLoops(isLooped ? -1 : 1, LoopType.Yoyo);
        }
    }
}
