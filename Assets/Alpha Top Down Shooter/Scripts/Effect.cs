using System.Collections;
using Pool;
using UnityEngine;

namespace Alpha
{
    public class Effect: MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particles;
        [SerializeField] private EffectPoolSO effectPool;
        [SerializeField] private AudioSource[] soundEffects;


        public void Play()
        {
            var random = Random.Range(0, 3);
            particles[random].Play();
            var randomSFX = Random.Range(0, 2);
            soundEffects[randomSFX].Play();
            StartCoroutine(ReturnEffect(5));
        }


        public void Play(int index)
        {
            particles[index].Play();
            soundEffects[3].Play();
            StartCoroutine(ReturnEffect(5));
        }

        private IEnumerator ReturnEffect(float time)
        {
            yield return new WaitForSeconds(time);
            effectPool.Return(this);
        }

    }
}