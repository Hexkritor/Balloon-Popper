using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

namespace Hexkritor.BalloonPopper.Data.Components
{
    [RequireComponent(typeof(SplineAnimate))]
    public class MovementLogic : MonoBehaviour
    {

        [SerializeField]
        [Min(0)]
        private float baseSpeed;

        private float speedMulitplier = 1;
        private bool isMoving = false;

        private SplineAnimate splineAnimation;
        private Coroutine splineMoveCompleteCoroutine;

        public event Action<float> OnSpeedChange = delegate { };
        public event Action OnMoveComplete = delegate { };

        public void Initialize()
        {
            isMoving = false;
            if (splineAnimation == null)
            {
                splineAnimation = GetComponent<SplineAnimate>();
            }
        }

        public void SetMulitplier(float value)
        {
            speedMulitplier = value;
            OnSpeedChange(speedMulitplier * baseSpeed);
            if (isMoving)
            {
                if (splineAnimation == null)
                {
                    splineAnimation = GetComponent<SplineAnimate>();
                }
                splineAnimation.MaxSpeed = speedMulitplier * baseSpeed;
            }
        }

        public void StartMove(SplineContainer splineTarget)
        {
            if (splineAnimation == null)
            {
                splineAnimation = GetComponent<SplineAnimate>();
            }
            if (splineTarget == null)
            {
                return;
            }
            splineAnimation.Container = splineTarget;
            splineAnimation.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimation.MaxSpeed = speedMulitplier * baseSpeed;
            splineAnimation.Restart(false);
            splineAnimation.Play();
            isMoving = true;
            if (splineMoveCompleteCoroutine != null)
            {
                StopCoroutine(splineMoveCompleteCoroutine);
            }
            splineMoveCompleteCoroutine = StartCoroutine(SendMoveCompleteEvent());
        }

        public void StopMove()
        {
            if (splineAnimation == null)
            {
                splineAnimation = GetComponent<SplineAnimate>();
            }
            splineAnimation.Pause();
        }

        public void StopMove(float time)
        {
            if (gameObject.activeSelf)
            {
                StartCoroutine(StopMoveCoroutine(time));
            }
        }

        public void ResumeMove()
        {
            if (splineAnimation == null)
            {
                splineAnimation = GetComponent<SplineAnimate>();
            }
            splineAnimation.Play();
        }

        private IEnumerator StopMoveCoroutine(float time)
        {
            StopMove();
            yield return new WaitForSeconds(time);
            ResumeMove();
        }

        private IEnumerator SendMoveCompleteEvent()
        {
            yield return new WaitUntil(() => splineAnimation.NormalizedTime == 1);
            OnMoveComplete();
            splineMoveCompleteCoroutine = null;
        }
    }
}
