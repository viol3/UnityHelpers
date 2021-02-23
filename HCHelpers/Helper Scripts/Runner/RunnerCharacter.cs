using Ali.Helper.TPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.Runner
{
    public class RunnerCharacter : MonoBehaviour
    {
        [SerializeField] private WorldCharacter _character;

        private Vector3 _velocity;

        public Vector3 Velocity { get => _velocity; set => _velocity = value; }

        void Update()
        {
            _character.ProcessVelocity(_velocity);
        }
    }
}