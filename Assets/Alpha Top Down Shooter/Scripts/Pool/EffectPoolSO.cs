using Alpha;
using Pool.Factory;
using UnityEngine;

namespace Pool
{
    [CreateAssetMenu(fileName = "NewEffectPool", menuName = "Pool/Effects Pool", order = 3)]
    public class EffectPoolSO : ComponentPoolSO<Effect>
    {
        [SerializeField] private EffectFactorySO factory;

        public override IFactory<Effect> Factory 
        {
            get => factory; 
            set => factory = value as EffectFactorySO; 
        }
    }
}