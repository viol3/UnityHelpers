using Ali.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Ali.Helper.TPS
{
    [RequireComponent(typeof(Rigidbody))]
    public class WorldCharacter : MonoBehaviour, IWorldCharacter
    {
        [SerializeField] private Transform _modelTransform;
        [SerializeField] private float _rotateSpeed = 100f;
        private IWorldCharacterAnimator _animator;
        private Rigidbody _rigidbody;
        private bool _rotateEnabled = true;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<IWorldCharacterAnimator>();
        }

        public void ProcessVelocity(Vector3 velocity)
        {
            _rigidbody.velocity = velocity;
            Vector3 eulerAngles = GameUtility.GetLookAtEulerAngles(Vector3.zero, velocity);
            eulerAngles.x = _modelTransform.eulerAngles.x;
            eulerAngles.z = _modelTransform.eulerAngles.z;
            if (_rotateEnabled)
            {
                _modelTransform.DORotate(eulerAngles, _rotateSpeed).SetSpeedBased();
            }
        }

        public void PlayAnimationState(string stateName)
        {
            if (_animator != null)
            {
                _animator.PlayAnimationState(stateName);
            }
        }

        public void SetRotationEnabled(bool value)
        {
            _rotateEnabled = value;
            if (!value)
            {
                _modelTransform.DOKill();
            }
        }
    }
}