using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.Audio
{
    public class AudioPool : MonoBehaviour
    {
        [SerializeField] private int _poolCount = 5;

        private AudioSource[] _audioSources;
        void Start()
        {
            _audioSources = new AudioSource[_poolCount];
            for (int i = 0; i < _poolCount; i++)
            {
                _audioSources[i] = gameObject.AddComponent<AudioSource>();
                _audioSources[i].playOnAwake = false;
            }
        }

        public void PlayClip(AudioClip clip, float volume = 1f, float pitch = 1f)
        {
            for (int i = 0; i < _audioSources.Length; i++)
            {
                if (!_audioSources[i].isPlaying)
                {
                    _audioSources[i].clip = clip;
                    _audioSources[i].volume = volume;
                    _audioSources[i].pitch = pitch;
                    _audioSources[i].Play();
                    return;
                }
            }
        }
    }
}