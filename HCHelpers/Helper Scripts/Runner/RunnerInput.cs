using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.Runner
{
    public class RunnerInput : MonoBehaviour
    {
        [SerializeField] private RunnerCharacter _runnerCharacter;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private float _forwardSpeed = 10;
        [SerializeField] private float _strafeSpeed = 10;
        [SerializeField] private bool _isEnabled = true;

        void Update()
        {
            if(_isEnabled)
            {
                _runnerCharacter.ProcessVelocity(new Vector3(_joystick.Direction.x * _strafeSpeed, 0f, _forwardSpeed));
            }
        }

        public void SetEnabled(bool value)
        {
            _isEnabled = value;
        }
    }
}