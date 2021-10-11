using Alpha.Bonuses;
using Pool.Factory;
using UnityEngine;

namespace Pool
{
    [CreateAssetMenu(fileName = "NewBonusPool", menuName = "Pool/Bonus Pool", order = 2)]
    public class BonusPoolSO : ComponentPoolSO<Bonus>
    {
        [SerializeField] private BonusFactorySO factory;

        public override IFactory<Bonus> Factory 
        {
            get => factory; 
            set => factory = value as BonusFactorySO; 
        }
    }
}