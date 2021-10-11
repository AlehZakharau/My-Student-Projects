using Alpha;
using UnityEngine;

namespace Pool.Factory
{
    [CreateAssetMenu(fileName = "NewBulletFactory", menuName = "Factories/Bullet Factory", order = 0)]
    public class BulletsFactorySO : FactorySO<Bullet>
    {
        [SerializeField] private Bullet bullet;
        
        public override Bullet Create()
        {
            return Instantiate(bullet);
        }
    }
}