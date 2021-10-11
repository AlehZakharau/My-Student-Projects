using Alpha;
using Pool.Factory;
using UnityEngine;

namespace Pool
{
    [CreateAssetMenu(fileName = "NewBulletPool", menuName = "Pool/Bullet Pool", order = 2)]
    public class BulletPoolSO : ComponentPoolSO<Bullet>
    {
        [SerializeField] private BulletsFactorySO factory;

        public override IFactory<Bullet> Factory 
        {
            get => factory; 
            set => factory = value as BulletsFactorySO; 
        }
    }
}