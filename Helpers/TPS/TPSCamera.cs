using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.TPS
{
    public class TPSCamera : LocalSingleton<TPSCamera>
    {
        [SerializeField] private bool _smooth;
        [SerializeField] private float _smoothSpeed;
        [SerializeField] private Vector3 _followAxes;
        [SerializeField] private Transform _target;

        private Vector3 _offset;
        private bool _active = true;

        private void Start()
        {
            _offset = transform.position - _target.position;
        }
        void Update()
        {
            if(!_active)
            {
                return;
            }
            if (_target)
            {
                Vector3 followPos = _target.position + _offset;
                followPos.x *= _followAxes.x;
                followPos.y *= _followAxes.y;
                followPos.z *= _followAxes.z;
                if (_smooth)
                {
                    transform.position = Vector3.Lerp(transform.position, followPos, _smoothSpeed * Time.deltaTime);
                }
                else
                {
                    transform.position = followPos;
                }

            }
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void SetOffset(Vector3 offset)
        {
            _offset = offset;
        }

        public Transform GetTarget()
        {
            return _target;
        }

        public void SetActive(bool active)
        {
            _active = active;
        }
    }
}