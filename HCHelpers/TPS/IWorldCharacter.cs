using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorldCharacter
{
    void ProcessVelocity(Vector3 velocity);
    void PlayAnimationState(string stateName);

}
