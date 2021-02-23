using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.TPS
{
    public interface IWorldCharacter
    {
        void ProcessVelocity(Vector3 velocity);
        void PlayAnimationState(string stateName);

    }
}