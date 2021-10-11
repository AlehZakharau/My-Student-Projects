using Alpha;
using Pool.Factory;
using UnityEngine;

namespace Pool
{
    [CreateAssetMenu(fileName = "NewParticleFactory", menuName = "Factories/Particle Factory", order = 3)]
    public class EffectFactorySO : FactorySO<Effect>
    {
        [SerializeField] private Effect effect;
        
        public override Effect Create()
        {
            return Instantiate(effect);
        }
    }
}