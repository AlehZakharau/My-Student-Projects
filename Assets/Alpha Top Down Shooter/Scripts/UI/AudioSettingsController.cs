using System;
using Alpha.Data;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Alpha.UI
{
    public class AudioSettingsController : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private Slider sliderSound;
        [SerializeField] private Slider sliderMusic;
        [SerializeField] private DataManager data;


        private void Start()
        {
            sliderSound.value = data.SoundVolume;
            sliderMusic.value = data.MusicVolume;
        }

        public void ChangeSoundVolume()
        {
            var volume = Mathf.Log10(sliderSound.value) * 20;
            mixer.SetFloat("SoundVolume", volume);
            data.SoundVolume = sliderSound.value;
        }

        public void ChangeMusicVolume()
        {
            var volume = Mathf.Log10(sliderMusic.value) * 20;
            mixer.SetFloat("MusicVolume", volume);
            data.MusicVolume = sliderMusic.value;
        }
    }
}