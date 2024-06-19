using System;
using Kandooz.InteractionSystem.Core;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Kandooz.InteractionSystem.Interactions
{
    [Serializable]
    public class FloatUnityEvent : UnityEvent<float>
    {
    }

    public class LeverInteractable : ConstrainedInteractableBase
    {
        public IObservable<float> OnLeverChanged => onLeverChanged.AsObservable();
        [SerializeField] private bool snapToCenter;
        [SerializeField] private float min, max;
        [SerializeField] private FloatUnityEvent onLeverChanged;

        [ReadOnly] [SerializeField] private float currentNormalizedAngle = 0;
        private float _oldNormalizedAngle = 0;


        private void Start()
        {
            OnDeselected
                .Where(_ => snapToCenter)
                .Do(_ => Rotate((max - min) / 2))
                .Do(_ => InvokeEvents())
                .Subscribe().AddTo(this);
        }

        protected override void Activate()
        {
        }

        protected override void StartHover()
        {
        }

        protected override void EndHover()
        {
        }

        private void Update()
        {
            if (!IsSelected) return;
            Rotate(CalculateAngle(transform.right));
            InvokeEvents();
        }

        private void Rotate(float x)
        {
            var angle = LimitAngle(x, min, max);
            interactableObject.transform.localRotation = Quaternion.Euler(angle, 0, 0);
            currentNormalizedAngle = (angle - min) / (max - min);
        }

        private void InvokeEvents()
        {
            var difference = currentNormalizedAngle - _oldNormalizedAngle;
            var absDifference = Mathf.Abs(difference);
            if (absDifference < .1f) return;
            _oldNormalizedAngle = currentNormalizedAngle;
            onLeverChanged.Invoke(currentNormalizedAngle);
        }

        private float CalculateAngle(Vector3 plane)
        {
            //-transform.right
            var direction = CurrentInteractor.transform.position - transform.position;
            direction = Vector3.ProjectOnPlane(direction, -plane).normalized;
            var angle = -Vector3.SignedAngle(direction, transform.up, plane);
            return angle;
        }

        private float LimitAngle(float angle, float min, float max)
        {
            if (angle > max) angle = max;

            if (angle < min) angle = min;

            return angle;
        }
    }
}