using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Hexkritor.Tools.DOTween
{
    [RequireComponent(typeof(RectTransform))]
    public class TweenAnchorPos : AbstractTween
    {

        [SerializeField]
        private Vector2 startPosition;
        [SerializeField]
        private Vector2 endPosition;


        public override void DoTween()
        {
            GetComponent<RectTransform>().DOAnchorPos(endPosition, duration).
                SetEase(easeType).
                From(startPosition).
                OnComplete(onTweenCompleted.Invoke);
        }
    }
}
