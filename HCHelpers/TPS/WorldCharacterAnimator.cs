using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCharacterAnimator : MonoBehaviour, IWorldCharacterAnimator
{
    [SerializeField] private Animator _animator;
    public void PlayAnimationState(string stateName)
    {
        _animator.Play(stateName);
    }
}
