using Alpha.Bonuses;
using Pool.Factory;
using UnityEngine;

namespace Pool
{
    [CreateAssetMenu(fileName = "NewBonusFactory", menuName = "Factories/Bonus Factory", order = 2)]
    public class BonusFactorySO : FactorySO<Bonus>
    {
        [SerializeField] private Bonus bonus;
        
        public override Bonus Create()
        {
            return Instantiate(bonus);
        }
    }
}