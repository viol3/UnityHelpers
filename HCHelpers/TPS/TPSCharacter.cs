using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.TPS
{
    public class TPSCharacter : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private bool _mapLimited;
        [SerializeField] private Vector3 _minMapLimit;
        [SerializeField] private Vector3 _maxMapLimit;

        private bool _moveEnabled = true;
        private Vector2 _input;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            UpdateVelocity();
            ClampPosition();
        }

        void UpdateVelocity()
        {
            if (_moveEnabled)
            {
                float velY = _rigidbody.velocity.y;
                _rigidbody.velocity = new Vector3(_input.x, 0f, _input.y) * _moveSpeed * Time.deltaTime;
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, velY, _rigidbody.velocity.z);
            }
            else
            {
                _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, 0f);
            }

        }

        void ClampPosition()
        {
            if (_mapLimited)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minMapLimit.x, _maxMapLimit.x), Mathf.Clamp(transform.position.y, _minMapLimit.y, _maxMapLimit.y), Mathf.Clamp(transform.position.z, _minMapLimit.z, _maxMapLimit.z));
            }
        }

        public Vector3 GetVelocity()
        {
            return _rigidbody.velocity;
        }

        public void SetMoveActive(bool value)
        {
            _moveEnabled = value;
        }

        public void SetInput(Vector2 input)
        {
            _input = input;
        }

    }
}