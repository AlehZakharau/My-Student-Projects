using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Asteroid
{
    public class AudioController : MonoBehaviour
    {
        public AudioMixer mixer;

        public Slider slider;

        private AudioSource buttonSound;
        private bool isSoundly = true;


        private void Awake()
        {
            buttonSound = GetComponent<AudioSource>();
        }

        private void Start()
        {
            slider.onValueChanged.AddListener(delegate { ChangeVolume(slider.value); });
        }

        public void AudioTurn()
        {
            buttonSound.Play();
            isSoundly = !isSoundly;
            var volume = 0f;
            mixer.SetFloat("Volume", volume = isSoundly ? 0 : -80);
        }

        private void ChangeVolume(float volume)
        {
            if (!buttonSound.isPlaying) buttonSound.Play();
            mixer.SetFloat("Volume", volume);
        }

    }
}