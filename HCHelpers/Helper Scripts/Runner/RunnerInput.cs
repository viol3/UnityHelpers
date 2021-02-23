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

        void Update()
        {
            _runnerCharacter.Velocity = new Vector3(_joystick.Direction.x * _strafeSpeed, 0f, _forwardSpeed);
        }
    }
}