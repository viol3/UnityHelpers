using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.TPS
{
    public class TPSCharacter : CharacterBase
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private AnimatorBase _animator;

        private Rigidbody _rigidbody;

        private bool _idle = false;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            ProcessVelocity(_joystick.Direction * _moveSpeed);
        }
        public override void ProcessVelocity(Vector3 velocity)
        {
            Vector3 charVelocity = new Vector3(velocity.x, 0f, velocity.y);
            _rigidbody.velocity = charVelocity;
            if(_idle && charVelocity.sqrMagnitude > 0.1f)
            {
                _idle = false;
                _animator.PlayAnimation("Run");
                _animator.SetSpeed(2f);
            }
            else if (!_idle && charVelocity.sqrMagnitude <= 0.1f)
            {
                _idle = true;
                _animator.PlayAnimation("Idle");
                _animator.SetSpeed(2f);
            }

            if(charVelocity.sqrMagnitude > 0.1f)
            {
                Vector3 eulerAngles = _animator.transform.eulerAngles;
                eulerAngles.y = -GameUtility.DirectionToAngle(_joystick.Direction) + 90;
                _animator.transform.eulerAngles = eulerAngles;
            }
        }
    }
}